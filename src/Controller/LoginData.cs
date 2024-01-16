using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Verwaltungssystem
{


    public class LoginData
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    [ApiController]
    [EnableCors("AllowPosts")]
    [Route("api/[controller]")]
//Meistens ist es so, oder eher schön, das für jede Produktart ein Controller gebaut wird, sprich ProductController, CustomerController, UserController, etc.
    public class LoginController : ControllerBase
    {

        [HttpPost("EmpfangeJson")]
        public IActionResult EmpfangeJson([FromBody] LoginData logindata)
        {


            int result = DatenbankLogin.GetLoginData(logindata.userName, logindata.password);
            if (result == 1)
            {
                return Ok();

            }
            else if (result == 0)
            {
                return Unauthorized();
            }
            else
            {
                return StatusCode(500);
            }

        }
    }

}
