using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Verwaltungssystem
{
    [ApiController]
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    public class KundenController:ControllerBase{

        [HttpGet("Anzahl")]
        public IActionResult GetKundenAnzahl(){

            int KundenAnzahl = KundenDatenbank.GetKundenAnzahl();
            return Ok(KundenAnzahl);

        }

    }
}
