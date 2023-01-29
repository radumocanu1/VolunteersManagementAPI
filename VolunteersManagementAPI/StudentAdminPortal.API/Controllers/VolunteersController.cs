using Microsoft.AspNetCore.Mvc;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels;
using System;
using VolunteersManagement.API.DomainModels.UpdateObjects;
using VolunteersManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using VolunteersManagement.API.Models.Enums;
using VolunteersManagement.API.Services.OperationsForServices;

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
            var volunteerList = await volunteerService.GetAllVolunteersAsync();
            if (volunteerList == null)
                return NotFound();
            
            return Ok(volunteerList);
        }

        [HttpGet]
        [Route("[controller]/byFullName/{firstName}/{lastName}")]
        public async Task<IActionResult> GetVolunteerByFullName(string firstName, string lastName)
        {
            var volunteer = await volunteerService.GetVolunteerByFullNameAsync(firstName, lastName);
            if (volunteer == null)
                return NotFound("No volunteer with the following name was found in the DataBase;");
            return Ok(volunteer);
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
        [HttpGet]
        [Route("[controller]/tasks/{volunteerId:guid}")]
        public async Task<IActionResult> getTasksByVolunteerIdASync([FromRoute] Guid volunteerId)
        {
            var tasks = await volunteerService.GetAllTasksAsync(volunteerId);
            if (tasks == null)
                return NotFound("No volunteer with the following Id was found in the DataBase or there isn't any task for him;");
            return Ok(tasks);

        }

        //only for admin
        [HttpGet]
 
        [Route("[controller]/admin/{volunteerId:guid}")]
        public async Task<IActionResult> getVolunteerByIdAdminAsync([FromRoute] Guid volunteerId)
        {
            var volunteer = await volunteerService.GetVolunteerByIdAsyncAdmin(volunteerId);
            if (volunteer == null)
                return NotFound("No volunteer with the following Id was found in the DataBase;");
            return Ok(volunteer);

        }
        [HttpPut]
        [Authorization(Roles.Admin)]
        [Route("[controller]/{volunteerId:guid}")]
        public async Task<IActionResult> UpdateVolunteerAsync([FromRoute] Guid volunteerId, [FromBody] UpdateVolunteer updateVolunteer)
        {
            var volunteer = await volunteerService.UpdateVolunteerByIdAsync(volunteerId,updateVolunteer);
            if (volunteer == null)
                return NotFound("No volunteer with the following Id was found in the DataBase;");
            return Ok(volunteer);

        }
        

        [HttpDelete]
        [Route("[controller]/{volunteerId:guid}")]
        public async Task<IActionResult> UpdateVolunteerAsync([FromRoute] Guid volunteerId)
        {
            var volunteer = await volunteerService.DeleteVolunteerByIdAsync(volunteerId);
            if (volunteer == null)
                return NotFound("No volunteer with the following Id was found in the DataBase;");
            return Ok(volunteer);
        }
        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> CreateVolunteerAsync([FromBody] CreateVolunteer createVolunteer)
        {
            
            return  Ok(await volunteerService.CreateVolunteerAsync(createVolunteer));
        }

    }
}
