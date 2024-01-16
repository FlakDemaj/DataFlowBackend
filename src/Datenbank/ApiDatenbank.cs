using MySql.Data.MySqlClient;



namespace Verwaltungssystem
{
    class Connector
    {
        public static MySqlConnection connection;
        public static string database = @"Data Source=localhost;
                                        Initial Catalog=verwaltungssystem;
                                        User Id=root;
                                        Password=Luffy2002!;";

        public static MySqlConnection GetConnection()
        {
            if (connection == null)
            {
                try
                {
                    connection = new MySqlConnection(database);
                }
                catch (MySqlException sqlexc)
                {
                    Console.WriteLine(sqlexc.Message);
                }

            }

            if (connection.State != System.Data.ConnectionState.Open)
            {
                try
                {

                    connection.Open();
                }
                catch (MySqlException sqlexc)
                {
                    Console.WriteLine(sqlexc.Message);
                }
            }
            return connection;

        }

        public static MySqlConnection CloseConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch (MySqlException sqlexc)
                {
                    Console.WriteLine(sqlexc.Message);
                }

            }
            return connection;

        }
    }
}    
        
