
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
