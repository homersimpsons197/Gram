using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
namespace MLib
{
    public static class COMMON
    {
        public static List<TextOperation> DecodeChain => new()
{
    TextOperation.UrlDecode,
    TextOperation.UriUnescape,
    TextOperation.HtmlDecode
};
        public enum TextOperation
        {
            HtmlEncode,
            HtmlDecode,
            UrlEncode,
            UrlDecode,
            UriEscape,
            UriUnescape,
            DecodeAll
        }

        public static string Transform(string input, TextOperation? single = null, IEnumerable<TextOperation>? multiple = null)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            string result = input;

            // Apply single operation if given
            if (single.HasValue)
            {
                result = Apply(result, single.Value);
            }

            if (multiple != null && multiple.Contains(TextOperation.DecodeAll))
            {
                foreach (var op in DecodeChain)
                {
                    result = Apply(result, op);
                }
            }
            else if (multiple != null && !multiple.Contains(TextOperation.DecodeAll))
            {
                foreach (var op in multiple)
                {
                    result = Apply(result, op);
                }
            }

            return result;
        }


        private static string Apply(string input, TextOperation op) => op switch
        {
            TextOperation.HtmlEncode => WebUtility.HtmlEncode(input),
            TextOperation.HtmlDecode => WebUtility.HtmlDecode(input),
            TextOperation.UrlEncode => WebUtility.UrlEncode(input),
            TextOperation.UrlDecode => WebUtility.UrlDecode(input),
            TextOperation.UriEscape => Uri.EscapeDataString(input),
            TextOperation.UriUnescape => Uri.UnescapeDataString(input),
            _ => input
        };

        public static void OpenAsTempFileName(string text)
        {
            string tempPath = Path.GetTempFileName();
            File.WriteAllText(tempPath, text);
            using (Process notepad = new Process())
            {
                notepad.StartInfo.FileName = "notepad.exe";
                notepad.StartInfo.Arguments = $"\"{tempPath}\"";
                notepad.Start();
                notepad.WaitForExit();
            }
        }

        public static List<string> MergeCollections(MatchCollection M1,  MatchCollection M2)
        {
            var count = Math.Min(M1.Count, M2.Count);

            var result = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string left = M1[i].Groups[1].Value;
                string right = M2[i].Groups[1].Value;
                result.Add($"{left}:{right}");
            }

            return result;
        }
    }
}