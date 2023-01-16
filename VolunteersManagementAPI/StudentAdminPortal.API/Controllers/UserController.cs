using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Models.Enums;
using VolunteersManagement.API.Repositories.UserRepository;
using VolunteersManagement.API.Services.OperationsForServices;
using VolunteersManagement.API.Services.UserService;

namespace VolunteersManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [Authorization(Roles.Admin)]

        [HttpPost("create/admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO userRequestDTO)
        {
            
            return Ok(await userService.Create(userRequestDTO));
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = userService.Atuhentificate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }
    }
}
