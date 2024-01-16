using MySql.Data.MySqlClient;

namespace Verwaltungssystem{

    public class MitarbeiterDatenbank{

        public static int GetMitarbeiterAnzahl(){

            int MitarbeiterAnzahl;
            string sqlQuery="Select Count(MitarbeiterID) as MitarbeiterAnzahl From Mitarbeiter";

            Connector.GetConnection();

            try{
                MySqlCommand command = new MySqlCommand(sqlQuery, Connector.connection);
                long result = (long)command.ExecuteScalar();
                MitarbeiterAnzahl =(int) result;
                return MitarbeiterAnzahl;
            } 
            catch(MySqlException msqlexc){
                Console.WriteLine(msqlexc.Message);
                return -1;
            }

        }

    }


}