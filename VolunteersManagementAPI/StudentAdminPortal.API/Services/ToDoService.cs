using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.DomainModels.UpdateObjects;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services.OperationsForServices;

namespace VolunteersManagement.API.Services
{
    public class ToDoService
    {
        private IVolunteerRepository repository;

        public ToDoService(IVolunteerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<ToDo>> getAllTasksAsync()
        {
            return await repository.GetAllTasksAsync();
        }

        public async Task<ToDo> GetTaskByIdAsync(Guid id)
        {
            var task = await repository.GetTaskByIdAsync(id);       
            if (task == null)
                return null;
            return task;
        }
        public async Task<ToDo> UpdateTaskByIdAsync(Guid taskId, UpdateTask task)
        {

            if (await repository.ExistTask(taskId))
            {
                var updatedTask = await repository.updateTaskAsync(new ToDo() {
                Id = taskId,
                Description = task.Description,
                Priority = task.Priority});

                return updatedTask;
            }
            return null;
        }
        public async Task<ToDo> DeleteTaskByIdAsync(Guid taskId)
        {
            if (await repository.ExistTask(taskId))
            {
                var deletedTask = await repository.DeleteTaskByIdAsync(taskId);
                return deletedTask;
            }
            return null;
        }
        public async Task<ToDo> CreateTaskAsync(ToDo createTask)
        {
            var createdTask = await repository.AddTaskAsync(createTask);
            return createdTask;
        }

    }
}
