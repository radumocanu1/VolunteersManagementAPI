
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories
{
    public interface IVolunteerRepository
    {
        Task<List<Volunteer>> GetVolunteersAsync();
        Task<Volunteer> GetVolunteerByFullNameAsync(string firstName, string lastName);

        Task<Volunteer> GetVolunteerByIdAsync(Guid id);

        Task<List<Gender>> GetGendersAsync();

        Task<bool> Exist(Guid id);

        Task<Volunteer> updateVolunteerAsync(Volunteer volunteer);

        Task<Gender> GetGenderByIdAsync(Guid id);

    }
}
