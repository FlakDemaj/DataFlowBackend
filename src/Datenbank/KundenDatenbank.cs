using MySql.Data.MySqlClient;


namespace Verwaltungssystem
{

    public class KundenDatenbank
    {

        public static int GetKundenAnzahl()
        {

            int KundenAnzahl;
            string sqlQuery = "Select count(KundenID) From Kunden";


            Connector.GetConnection();

            try
            {
                MySqlCommand command = new MySqlCommand(sqlQuery, Connector.connection);

                long anzahl = (long)command.ExecuteScalar();
                KundenAnzahl = (int)anzahl;
                return KundenAnzahl;

            }
            catch (MySqlException sqlexc)
            {
                Console.WriteLine(sqlexc.Message);
                return -1;
            }

        }

    }



}