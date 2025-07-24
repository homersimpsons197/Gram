using System.Data.SQLite;

namespace GramR.Controller
{
    public static class DB
    {
        private static readonly string _connectionString =
            $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "igdb.db")};Version=3;";

        public static async Task<int> AddAccountsAsync(string username, string password, string apd)
        {
            var query = @"
INSERT OR IGNORE INTO Accounts 
(User, Pass, Date, Apd) 
VALUES (@User, @Pass, @Date, @Apd)";

            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                using var command = new SQLiteCommand(query, connection);

                command.Parameters.AddWithValue("@User", username);
                command.Parameters.AddWithValue("@Pass", password);
                command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Apd", apd);

                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddAccountsAsync error: {ex.Message}");
                return 0;
            }
        }

        public static async Task<int> AddUsersAsync(List<string> idList)
        {
            var query = @"
INSERT OR IGNORE INTO Users 
(Id) 
VALUES (@Id)";

            int totalRowsAffected = 0;

            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                using var command = new SQLiteCommand(query, connection);

                await connection.OpenAsync();

                foreach (var userId in idList)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Id", userId);
                    totalRowsAffected += await command.ExecuteNonQueryAsync();
                }

                return totalRowsAffected;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddUsersAsync error: {ex.Message}");
                return 0;
            }
        }

        public static async Task<bool> UpdateDateAndApdAsync(string username)
        {
            var selectQuery = @"SELECT Apd FROM Accounts WHERE User = @User";
            var updateQuery = @"UPDATE Accounts SET Date = @Date, Apd = @Apd WHERE User = @User";

            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                await connection.OpenAsync();

                using var selectCommand = new SQLiteCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@User", username);

                using var reader = await selectCommand.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    string apdText = reader.GetString(0); // Since only Apd is selected
                    int apdValue = int.TryParse(apdText, out var result) ? result : 0;
                    string updatedApd = (apdValue + 3 > 200) ? "200" : (apdValue + 3).ToString();

                    using var updateCommand = new SQLiteCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                    updateCommand.Parameters.AddWithValue("@Apd", updatedApd);
                    updateCommand.Parameters.AddWithValue("@User", username);

                    await updateCommand.ExecuteNonQueryAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateDateAndApdAsync error: {ex.Message}");
                return false;
            }
        }

        public static async Task<bool> ValidateDateAsync(string username)
        {
            var selectQuery = @"SELECT Date FROM Accounts WHERE User = @User";

            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                await connection.OpenAsync();

                using var selectCommand = new SQLiteCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@User", username);

                using var reader = await selectCommand.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    string dateText = reader.GetString(0);
                    if (DateTime.TryParse(dateText, out DateTime storedDate))
                    {
                        return storedDate < DateTime.Now;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ValidateDateAsync error: {ex.Message}");
                return false;
            }
        }

        public static async Task<int> DeleteAsync(string table, string identifier)
        {
            string query = table switch
            {
                "Accounts" => "DELETE FROM Accounts WHERE User = @Identifier",
                "Users" => "DELETE FROM Users WHERE Id = @Identifier",
                _ => throw new ArgumentException("Invalid table name")
            };

            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                using var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@Identifier", identifier);

                await connection.OpenAsync();
                return await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteAsync error: {ex.Message}");
                return 0;
            }
        }

        public static async Task<int> GetRowCountAsync(string table)
        {
            var query = $"SELECT COUNT(*) FROM [{table}]";

            try
            {
                using var connection = new SQLiteConnection(_connectionString);
                using var command = new SQLiteCommand(query, connection);

                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();

                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetRowCountAsync error: {ex.Message}");
                return -1; // or 0 if you prefer to treat errors as "empty"
            }
        }
    }
}