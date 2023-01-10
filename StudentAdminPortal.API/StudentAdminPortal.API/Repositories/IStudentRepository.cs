
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Volunteer>> GetVolunteersAsync();
    }
}
