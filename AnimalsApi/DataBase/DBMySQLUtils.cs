using MySql.Data.MySqlClient;

namespace AnimalsApi.DataBase
{
    public class DBMySQLUtils
    {
        public static string host { get; set; } = "localhost";
        public static string port { get; set; } = "";
        public static string userid { get; set; } = "";
        public static string password { get; set; } = "";
        public static string database { get; set; } = "";

        public MySqlConnection CreateSchemaConnection()
        {
            String connectionString = $"server={host};port={port};userid={userid};password={password}";
            return new MySqlConnection(connectionString);
        }

        public MySqlConnection GetMySQLConnection()
        {
            String connectionString = $"server={host};port={port};userid={userid};password={password};database={database}";
            return new MySqlConnection(connectionString);
        }
    }
}
    }
}