using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DAL.DB.DBDeployment
{
    public static class DatabaseDeployment
    {
        private const string _filesLocation = @"..\..\..\DAL\DB\SQLScripts";
        private const string _filesExtension = "*.sql";
        private static readonly Regex _regex = new Regex(@"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        public static bool ExpandTheDatabase(string serverConnectionString = @"Data Source=KONSTANTINPC\SQLEXPRESS; Initial Catalog=master; Integrated Security=true;")
        {
            try
            {
                string[] files = Directory.GetFiles(_filesLocation, _filesExtension).Select(Path.GetFileName).ToArray();
                using var connection = new SqlConnection(serverConnectionString);
                connection.Open();

                foreach (var fileName in files)
                {
                    string script = File.ReadAllText(Path.Combine(_filesLocation, fileName));
                    IEnumerable<string> commands = _regex.Split(script);
                    foreach (string command in commands.Where(command => command.Trim() != ""))
                    {
                        using var sqlCommand = new SqlCommand(command, connection);
                        sqlCommand.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}