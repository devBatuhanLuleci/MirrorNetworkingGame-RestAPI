using ACG_Master.DataBase.Access;
using ACG_Master.DataBase.Dtos;
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
        /// api/auth/login/{walletId}
        /// if moralis Id is available return User model else return badrequest client must register.
        /// </summary>
        [HttpGet("login/{walletId}")]
        public IActionResult Login(string walletId)
        {
            try
            {
                // TODO: burası walletId olarak değiştirilecek
                var user = _authService.GetByWalletId(walletId);
                if (user == null) return NotFound(new { walletId });
                _authService.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="userData">User info from request body</param>
        /// <returns></returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userData)
        {
            try
            {
                var user = _authService.GetByWalletId(userData.WalletId);

                if (user != null)
                {
                    return Conflict("user already registred.");
                }
                else
                {
                    user = _mapper.Map<UserDto, User>(userData);
                    _authService.Add(user);
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #region x-www-form-urlencoded
        /// <summary>
        /// Creating new user
        /// </summary>
        /// <param name="userData">User info from request body</param>
        /// <returns></returns>
        [HttpPost("create")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Create([FromForm] UserDto userData)
        {
            try
            {
                var user = _authService.GetByWalletId(userData.WalletId);

                if (user != null)
                {
                    user = _mapper.Map(userData, user);
                    _authService.Update(user);
                }
                else
                {
                    user = _mapper.Map<UserDto, User>(userData);
                    user.AccessToken = Guid.NewGuid().ToString();
                    _authService.Add(user);

                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("Master/GetUser/{accessToken}")]
        public IActionResult GetUserForMaster(string accessToken)
        {
            try
            {
                // check user
                var user = _authService.GetUserByAccessTokenId(accessToken);
                if (user == null) return NotFound(new { accessToken });
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion



        [HttpGet("getUser/{wallet}")]
        public IActionResult GetUser(string wallet)
        {
            try
            {
                // check user
                var user = _authService.GetByWalletId(wallet);
                if (user == null) return NotFound(new { wallet });
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("isRegistered/{walletId}")]
        public IActionResult IsRegistered(string walletId)
        {
            try
            {
                var user = _authService.GetByWalletId(walletId);
                return Ok(user != null);

            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("isUserNameAvailable/{userName}")]
        public IActionResult IsUserNameAvailable(string userName)
        {
            try
            {
                var user = _authService.GetByUserName(userName);
                return Ok(user != null);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("isEmailAvailable/{email}")]
        public IActionResult IsEmailAvailable(string email)
        {
            try
            {
                var user = _authService.GetByEmail(email);
                return Ok(user != null);
            }
            catch (Exception ex)
            {
                Console.Write($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            return Ok(user);

        }

        [HttpPost]
        public IActionResult AddCoin([FromBody] string wallet, [FromBody] int count)
        {
            var user = _authService.GetByWalletId(wallet);
            if (user == null) return NotFound(new { wallet });
            user.Coins += count;
            _authService.Update(user);
            return Ok();
        }
    }
}
