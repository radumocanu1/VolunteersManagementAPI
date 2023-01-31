using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;

namespace VolunteersManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private ToDoService toDoService;

        public ToDoController(IVolunteerRepository repository)
        {
            this.toDoService = new ToDoService(repository);
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllTasks() 
        {
            var tasksList = await toDoService.getAllTasksAsync();
            if (tasksList == null)
                return NotFound();

            return Ok(tasksList);
        }
    }
}
