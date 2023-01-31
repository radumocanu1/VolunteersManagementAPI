using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.DomainModels.UpdateObjects;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Models.Enums;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;
using VolunteersManagement.API.Services.OperationsForServices;

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
        [HttpGet]
        [Route("{taskId:guid}")]
        public async Task<IActionResult> getTaskByIdAsync([FromRoute] Guid taskId)
        {
            var task = await toDoService.GetTaskByIdAsync(taskId);
            if (task == null)
                return NotFound("No task with the following Id was found in the DataBase;");
            return Ok(task);

        }
        [HttpPut]
        [Route("{taskId:guid}")]
        public async Task<IActionResult> UpdateTaskAsync([FromRoute] Guid taskId, [FromBody] UpdateTask updateTask)
        {
            var task = await toDoService.UpdateTaskByIdAsync(taskId, updateTask);
            if (task == null)
                return NotFound("No task with the following Id was found in the DataBase;");
            return Ok(task);

        }

        [HttpDelete]
        [Route("{taskId:guid}")]
        public async Task<IActionResult> DeleteTaskAsync ([FromRoute] Guid taskId)
        {
            var task = await toDoService.DeleteTaskByIdAsync(taskId);
            if (task == null)
                return NotFound("No task with the following Id was found in the DataBase;");
            return Ok(task);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateTaskAsync([FromBody] ToDo toDo)
        {
            var task = await toDoService.CreateTaskAsync(toDo);
            if (task == null)
                return NotFound("No task with the following Id was found in the DataBase;");
            return Ok(task);

        }
    }
}
