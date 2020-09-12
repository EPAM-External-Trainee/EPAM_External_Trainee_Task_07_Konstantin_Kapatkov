using System;
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

        public static void ExpandTheDatabase(string serverConnectionString)
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
                    foreach (var command in commands.Where(command => command.Trim() != ""))
                    {
                        using var sqlCommand = new SqlCommand(command, connection);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}