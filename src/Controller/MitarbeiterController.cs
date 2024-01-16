using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Verwaltungssystem
{
    [ApiController]
    [EnableCors("AllowAny")]
    [Route("api/[controller]")]
    public class MitarbeiterController:ControllerBase{

        [HttpGet("Anzahl")]
        public IActionResult GetMitarbeiterAnzahl(){

            int MitarbeiterAnzahl = MitarbeiterDatenbank.GetMitarbeiterAnzahl();
            return Ok(MitarbeiterAnzahl);

        }

    }
}
