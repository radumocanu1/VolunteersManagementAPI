using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VolunteersManagement.API.Services
{
    public class VolunteerService
    {

        private readonly IVolunteerRepository volunteerRepository;
        public VolunteerService(IVolunteerRepository volunteerRepository) 
        {
            this.volunteerRepository = volunteerRepository;
        }
        public async Task<List<DtoVolunteer>> GetAllVolunteersAsync()
        {
            var volunteers = await volunteerRepository.GetVolunteersAsync();
            var dtoVolunteersList = new List<DtoVolunteer>();
            foreach (var volunteer in volunteers)
            {
                dtoVolunteersList.Add(ConvertToDto(volunteer));
            }
            return dtoVolunteersList;
        }
        public async Task<Volunteer> GetVolunteerByFullNameAsync(string firstName, string lastName)
        {
            return await volunteerRepository.GetVolunteerByFullNameAsync(firstName, lastName);
        }
        private DtoVolunteer ConvertToDto(Volunteer volunteer)
        {
            return new DtoVolunteer()
            {
                Id = volunteer.Id,
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                DateOfBirth = volunteer.DateOfBirth,
                Email = volunteer.Email,
                ProfileImageUrl = volunteer.ProfileImageUrl,
                Gender = volunteer.Gender
            };
        }
        

    }
}
