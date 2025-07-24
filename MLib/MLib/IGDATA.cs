using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Sodium;

namespace MLib
{
    public static class IGDATA
    {
        public static Dictionary<string, string> DataDict { get; set; } = new Dictionary<string, string>();        
        
        public static void SetDictionary(string text)
        {
            var patterns = new Dictionary<string, string>
    {
        { "X-IG-App-ID", @"""X-IG-App-ID"":""(.*?)""" },
        { "X-Instagram-AJAX", @"client_revision"":(.*?)," },
        { "KeyId", @"""key_id"":""(.*?)""" },
        { "PublicKey", @"""public_key"":""(.*?)""" },
        { "Version", @"""version"":""(.*?)""\}," }
    };

            foreach (var kvp in patterns)
            {
                var value = Extract(text, kvp.Value);
                AddHeaderIfNotEmpty(kvp.Key, value);
            }
            
            var sprinkleVersion = Extract(text, @"""jazoest"",""version"":(.*?),");
            var csrfToken = Extract(text, @"""csrf_token"":""(.*?)""\},");
            if (!string.IsNullOrWhiteSpace(sprinkleVersion) && !string.IsNullOrWhiteSpace(csrfToken))
            {
                var jazoest = GenerateJazoest(sprinkleVersion, csrfToken);
                AddHeaderIfNotEmpty("Jazoest", jazoest);
            }
        }
        //Helpers for optimized regex func
        private static string Extract(string input, string pattern)
        {
            return Regex.Match(input, pattern, RegexOptions.Singleline).Groups[1].Value;
        }

        private static void AddHeaderIfNotEmpty(string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
                DataDict[key] = value;
        }

        public static bool IsEncodingZstd(HttpContentHeaders headers)
        {
            return headers.ContentEncoding.Any(enc => enc.Equals("zstd", StringComparison.OrdinalIgnoreCase));
        }

        public static async Task<string> ZstdStreamingDecoder(byte[] compressed)
        {
            try
            {
                using var input = new MemoryStream(compressed);
                using var output = new MemoryStream();
                using var decompressor = new ZstdNet.DecompressionStream(input);

                await decompressor.CopyToAsync(output);
                return Encoding.UTF8.GetString(output.ToArray());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to decode Zstd-compressed content.", ex);
            }
        }
        
        public static string EncryptPassword(string password, string publicKey, string keyId, string version)
        {
            var time = DateTime.UtcNow.ToTimestamp();
            var keyBytes = publicKey.HexToBytes();
            var key = new byte[32];
            new Random().NextBytes(key);
            var iv = new byte[12];
            var tag = new byte[16];
            var plainText = Encoding.UTF8.GetBytes(password);
            var cipherText = new byte[plainText.Length];
            using (var cipher = new AesGcm(key, tagSizeInBytes: 16))
            {
                cipher.Encrypt(nonce: iv,
                    plaintext: plainText,
                    ciphertext: cipherText,
                    tag: tag,
                    associatedData: Encoding.UTF8.GetBytes(time.ToString()));
            }

            var encryptedKey = SealedPublicKeyBox.Create(key, keyBytes);
            var bytesOfLen = BitConverter.GetBytes((short)encryptedKey.Length);
            var info = new byte[] { 1, byte.Parse(keyId) };
            var bytes = info.Concat(bytesOfLen).Concat(encryptedKey).Concat(tag).Concat(cipherText);

            var str = $"#PWD_BROWSER:{version}:{time}:{Convert.ToBase64String(bytes)}";
            return COMMON.Transform(
                input: str,
                single: COMMON.TextOperation.UrlEncode
                );
        }

        private static readonly DateTime _jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToTimestamp(this DateTime d)
        {
            return (long)(d.ToUniversalTime() - _jan1St1970).TotalSeconds;//return Unix timestamp from jan1St1970 to this exact time in seconds
        }

        public static byte[] HexToBytes(this string hex)
        {
            return Enumerable.Range(0, hex.Length / 2) //Each byte is made from 2 hex character so byteArray.Length = hex value/2

                //Basically mean, for each "x" starting from 0:
                //x=0; x*2=0; =>grab hex[0..2] * x=1; x*2=2; =>grab hex[2..4] ... until we reached 16 bytes, which mean 32 hex characters
                .Select(x => Convert.ToByte(hex.Substring(x * 2, 2), 16))
                .ToArray();
        }

        //Generic Extension Method for Array
        public static T[] Concat<T>(this T[] x, T[] y)
        {
            //T is placeholder for any type
            //T is basically anything but equation with multiple values must match type or will throw error
            var z = new T[x.Length + y.Length];
            x.CopyTo(z, 0);
            y.CopyTo(z, x.Length);
            return z;
        }

        public static string GenerateJazoest(string sprinkleVersion, string htmlBasedCsrfToken)
        {
            var newJazoest = 0;

            foreach (char c in htmlBasedCsrfToken)
            {
                newJazoest += (int)c;
            }
            return newJazoest.ToString() + sprinkleVersion;
        }

        public static List<string> ExtractJsonUserData(string text)
        {
            var matches = Regex.Matches(text, @"(?:""user"": \{)(.*?)(?:\})", RegexOptions.Singleline);
            
            var resultString = string.Join(", ",
                matches.Cast<Match>()
                .Select(m => m.Groups[1].Value));

            var ids = Regex.Matches(resultString, @"(?:""pk"": "")(.*?)(?:"",)", RegexOptions.Singleline);
            var usernames = Regex.Matches(resultString, @"(?:""username"": "")(.*?)(?:"",)", RegexOptions.Singleline);

            return COMMON.MergeCollections(usernames, ids);
        }
    }
}
