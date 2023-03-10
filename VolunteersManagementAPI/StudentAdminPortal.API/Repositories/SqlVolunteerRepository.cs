
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories
{
    public class SqlVolunteerRepository : IVolunteerRepository
    {
        private readonly VolunteerManagementContext context;
        public SqlVolunteerRepository(VolunteerManagementContext context)
        {
            this.context = context; 
        }
        public async Task<List<Volunteer>> GetVolunteersAsync()
        {
            return await context.Volunteer.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
        public async Task<Volunteer> GetVolunteerByFullNameAsync(string FirstName,string LastName)
        {
            return await context.Volunteer.FirstOrDefaultAsync(v => v.FirstName == FirstName && v.LastName == LastName);
        }

        public async Task<Volunteer> GetVolunteerByIdAsync(Guid id)
        {
            return await context.Volunteer.Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Gender>> GetGendersAsync()
        {
           return await context.Gender.ToListAsync();
        }

      
        public async Task<bool> Exist(Guid id)
        {
            return await context.Volunteer.AnyAsync(v => v.Id == id);
        }

        public async Task<Volunteer> updateVolunteerAsync(Volunteer volunteer)
        {
            var volunteerToUpdate = await GetVolunteerByIdAsync(volunteer.Id);
            if (volunteerToUpdate != null)
            {
                volunteerToUpdate.PhoneNumber = volunteer.PhoneNumber;
                volunteerToUpdate.LastName = volunteer.LastName;
                volunteerToUpdate.FirstName = volunteer.FirstName;
                volunteerToUpdate.GenderId= volunteer.GenderId;
                volunteerToUpdate.Address = volunteer.Address;
                volunteerToUpdate.Email = volunteer.Email;
                volunteerToUpdate.DateOfBirth = volunteer.DateOfBirth;
                await context.SaveChangesAsync();
                return volunteerToUpdate;
            }
            return null;
        }

        public async Task<Gender> GetGenderByIdAsync(Guid id)
        {
            return await context.Gender.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Volunteer> DeleteVolunteerByIdAsync(Guid id)
        {
            var volunteerToDelete = await GetVolunteerByIdAsync(id);
            if (volunteerToDelete != null)
            {
                context.Volunteer.Remove(volunteerToDelete);
                await context.SaveChangesAsync();
                return volunteerToDelete;
            }
            return null;
        }

        public async Task<Volunteer> AddVolunteerAsync(Volunteer volunteer)
        {
            var addedVolunteer = await context.AddAsync(volunteer);
            await context.SaveChangesAsync();
            return addedVolunteer.Entity;
        }

        public async Task<IQueryable<ToDo>> GetAllTasksASync(Guid id)
        {
            var tasks =
                        from toDo in context.ToDo
                        where toDo.manyToMany.Any(m => m.VolunteerId == id)
                        select toDo;


            return await Task.FromResult(tasks);
        }

        public async Task<List<ToDo>> GetAllTasksAsync()
        {
            return await context.ToDo.ToListAsync();
        }

        public async Task<bool> ExistTask(Guid id)
        {
            return await context.ToDo.AnyAsync(t => t.Id == id);
        }

        public async Task<ToDo> updateTaskAsync(ToDo task)
        {
            var taskToUpdate = await GetTaskByIdAsync(task.Id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Priority = task.Priority;
                taskToUpdate.Description = task.Description;
                await context.SaveChangesAsync();
                return taskToUpdate;
            }
            return null;
        }

        public async Task<ToDo> DeleteTaskByIdAsync(Guid id)
        {
            var taskToDelete = await GetTaskByIdAsync(id);
            if (taskToDelete != null)
            {
                context.ToDo.Remove(taskToDelete);
                await context.SaveChangesAsync();
                return taskToDelete;
            }
            return null;
        }

        public async Task<ToDo> AddTaskAsync(ToDo task)
        {
            var addedTask = await context.AddAsync(task);
            await context.SaveChangesAsync();
            return addedTask.Entity;
        }

        public async Task<ToDo> GetTaskByIdAsync(Guid id)
        {
            return await context.ToDo.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
