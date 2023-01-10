
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly VolunteerManagementContext context;
        public SqlStudentRepository(VolunteerManagementContext context)
        {
            this.context = context; 
        }
        public async Task<List<Volunteer>> GetVolunteersAsync()
        {
            return await context.Volunteer.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
