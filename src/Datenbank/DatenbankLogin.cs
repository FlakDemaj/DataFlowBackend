using MySql.Data.MySqlClient;

namespace Verwaltungssystem
{

    public class DatenbankLogin
    {



        public static int GetLoginData(string email, string passwort)
        {
            int isInDB;

            Connector.GetConnection();

            string sqlQuery = @"SELECT CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END  
                                From logindata 
                                Where Email = @email 
                                AND passwort =@passwort";
            try
            {
                MySqlCommand command = new MySqlCommand(sqlQuery, Connector.connection);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@passwort", passwort);
                Console.WriteLine(command.ExecuteScalar().ToString());

                long result = (long)command.ExecuteScalar();
                isInDB = (int)result;
                return isInDB;

            }
            catch (MySqlException sqlexc)
            {
                Console.WriteLine(sqlexc.Message);
                return -1;
            }

            finally
            {
                Connector.CloseConnection();
            }

        }

    }
}
