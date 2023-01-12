using Microsoft.AspNetCore.Mvc;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels;
using System;

namespace VolunteersManagement.API.Controllers
{
    [ApiController]
    public class VolunteersController : Controller
    {
        private VolunteerService volunteerService;

        public VolunteersController(IVolunteerRepository volunteerRepository)
        {
          this.volunteerService = new VolunteerService(volunteerRepository);
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllVolunteers()
        {
            return Ok( await volunteerService.GetAllVolunteersAsync());
        }

        [HttpGet]
        [Route("[controller]/byFullName/{firstName}/{lastName}")]
        public async Task<IActionResult> GetVolunteerByFullName(string firstName, string lastName)
        {
            return Ok(await volunteerService.GetVolunteerByFullNameAsync(firstName, lastName));
        }
        [HttpGet]
        [Route("[controller]/{volunteerId:guid}")]
        public async Task<IActionResult> getVolunteerByIdAsync([FromRoute]Guid volunteerId)
        {
            var volunteer = await volunteerService.GetVolunteerByIdAsync(volunteerId);
            if (volunteer == null)
                return NotFound("No volunteer with the following Id was found in the DataBase;");
            return Ok(volunteer);

        }

    }
}
