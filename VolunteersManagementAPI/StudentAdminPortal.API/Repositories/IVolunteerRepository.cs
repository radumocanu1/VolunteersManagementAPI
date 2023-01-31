
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories
{
    public interface IVolunteerRepository
    {

        Task<List<Volunteer>> GetVolunteersAsync();

        Task<List<ToDo>> GetAllTasksAsync();
        Task<Volunteer> GetVolunteerByFullNameAsync(string firstName, string lastName);

        Task<Volunteer> GetVolunteerByIdAsync(Guid id);

        Task<ToDo> GetTaskByIdAsync(Guid id);

        Task<List<Gender>> GetGendersAsync();

        Task<bool> Exist(Guid id);

        Task<bool> ExistTask(Guid id);

        Task<Volunteer> updateVolunteerAsync(Volunteer volunteer);


        Task<ToDo> updateTaskAsync(ToDo task);

        Task<Gender> GetGenderByIdAsync(Guid id);

        Task<Volunteer> DeleteVolunteerByIdAsync(Guid id);

        Task<ToDo> DeleteTaskByIdAsync(Guid id);

        Task<Volunteer> AddVolunteerAsync(Volunteer volunteer);

        Task<ToDo> AddTaskAsync(ToDo task);
        Task<IQueryable<ToDo>> GetAllTasksASync(Guid id);

        
    }
}
