using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;

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
    }
}
