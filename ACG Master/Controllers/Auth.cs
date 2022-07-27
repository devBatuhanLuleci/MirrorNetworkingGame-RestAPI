using ACG_Master.DataBase;
using ACG_Master.DataBase.Access;
using ACG_Master.DataBase.Entities;
using ACG_Master.Mapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ACG_Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        private AuthService _authService;
        private IMapper _mapper;

        public Auth(AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        ///<summary>
        /// api/auth/login/{moralisId}
        /// if moralis Id is available return User model else return badrequest client must register.
        /// </summary>
        [HttpGet("login/{moralisId}")]
        public IActionResult Login(string moralisId)
        {
            // check user
            var user = _authService.Get(moralisId);
            if (user == null) return NotFound(new { moralisId });
            return Ok(user);
        }

        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="userData">User info from request body</param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create([FromBody] UserDto userData)
        {
            /*
             {
  "moralisId": "abc123",
  "nickName": "exop",
  "firstName": "exop",
  "lastName": "exopl",
  "email": "test@test.com"
}
             */
            try
            {
                var user = _authService.Get(userData.MoralisId);
                if (user != null) return BadRequest("User already created!");
                user = _mapper.Map<UserDto, User>(userData);
                _authService.Add(user);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



    }
}
