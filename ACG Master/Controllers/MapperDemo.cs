using ACG_Master.DataBase;
using ACG_Master.DataBase.Entities;
using ACG_Master.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACG_Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapperDemo : ControllerBase
    {
        IMapper mapper;
        public MapperDemo(IMapper _mapper)
        {
            mapper = _mapper;
        }
        [HttpGet]
        public UserDto Index()
        {

            var user = new User();

            UserDto userDto = mapper.Map<User, UserDto>(user);
            return userDto;
        }
    }
}
