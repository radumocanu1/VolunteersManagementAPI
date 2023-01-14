using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;

namespace VolunteersManagement.API.Controllers
{
    [ApiController]
    public class GendersController : Controller
    {
        private GenderService genderService;
        public GendersController(IVolunteerRepository volunteerRepository) {
            this.genderService = new GenderService(volunteerRepository);

        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders() {
            var genderList = await genderService.GetGendersAsync();
            if (genderList == null)
                return NotFound();
            return Ok(genderList);
        }
    }
}
