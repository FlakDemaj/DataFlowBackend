using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Verwaltungssystem
{
    public class Program
    {
        public static void Main(string[] args) //args kann auch eigentlich weg, braucht man nicht da dieser immer leer ist aber lassen wir jetzt einfach mal da
        {
            CreateHostBuilder(args).Build().Run();//Host wird erstellt und ausgeführt, Website ist wie ein Auto und Host wie eine Garage
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)//Garage wird gebaut, die Grundlegenden Sachen die eine Website benötigt, werden eingerichtet
            //Dies ist ein MEthodenaufruf mit einer anonymen Funtkion
                .ConfigureWebHostDefaults(webBuilder => //Hier wird jetzt die Garage (Host) nach meinen Wünschen angepasst, den er aus dem unteren Befehl entnimmt
                {
                    webBuilder.UseStartup<Startup>();//Er soll nun die Anweisungen zum Starten der Garage(Host) in dem Startup befolgen und den Host ausführen, er nimmt aus dem Startup die ConfigureService und Configure Klasse
                });
    }
}
