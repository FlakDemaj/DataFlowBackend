using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Verwaltungssystem
{
    public class Startup
    {
        //Hier werden verschiedene CORS-Regeln bestimmt, sprich was die Methode machen darf(Delelte, POST, GET, SET), 
        //ob Anfrange von HTTP und/oder HTPPS erlaubt sind
        //Welche Infos der Header(Generelle Infos wie der Browser, Cookie, Medientypen(test, html, pdf ,json,mp3...)) haben darf
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors(options =>
            {
                //Hier werden alle Sachen erlaubt
                options.AddPolicy("AllowPosts",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .WithMethods("Posts")
                           .AllowAnyHeader();
                });


                options.AddPolicy("AllowGet",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .WithMethods("Get")
                           .AllowAnyHeader();
                });

                options.AddPolicy("AllowSet",
                builder => 
                {
                    builder.AllowAnyOrigin()
                            .WithMethods("Set")
                            .AllowAnyHeader();

                });

                options.AddPolicy("AllowAny",
                 builder =>
                 {
                     builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                 });


            });
            //Neue CORS-Regelungen erstellen für POST, GET, text, bla bla damit es sicherer ist

        }

        public void Configure(IApplicationBuilder app)
        {
            // Hier kannst du Middleware hinzufügen und konfigurieren. Weitere Hinzufügen klappt so:
            //app.UseCors(NameDerRichtlinie), beliebig viele von denen

            app.UseRouting();//Er bereitet sozsuagen den Weg vor, mit Schildern und alles und sagt dem Plozisten, dass er ready ist
            app.UseCors("AllowPosts");
            app.UseCors("AllowAny");
            app.UseCors("AllowGet");
            app.UseCors("AllowSet");
            //Dies unten ist eine Methode mit einem lambda Ausdruck als Eingabeargument
            app.UseEndpoints(endpoints =>//So wie ein Polizist der alle Autos lotzt wohin die Fahren sollen,
            {
                endpoints.MapControllers();//Er sagt dem Plozist, dass er jede Straße im Auge behalten soll
                //Informiere dich über Erweiterungsmethoden
            });

            //Siehe dir Areas an, um es überischtlicher zu gestalten bei größeren Projektem
        }
    }
}
