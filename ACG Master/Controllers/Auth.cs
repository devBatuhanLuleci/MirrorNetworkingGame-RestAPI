using ACG_Master.DataBase.Access;
using ACG_Master.DataBase.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACG_Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        AuthService authService;

        public Auth(AuthService authService)
        {
            this.authService = authService;
        }
        ///<summary>
        /// api/auth/login/{moralisId}
        /// Auth model dönecek login veya register durumu belirtecek.
        /// </summary>
        [HttpGet("login/{moralisId}")]
        public string Login(string moralisId)
        {
            return "hello";
        }



  
    }
}
