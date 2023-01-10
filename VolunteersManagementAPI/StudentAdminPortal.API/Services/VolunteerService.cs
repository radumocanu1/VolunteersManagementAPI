using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.Services.OperationsForServices;

namespace VolunteersManagement.API.Services
{
    public class VolunteerService
    {

        private readonly IVolunteerRepository volunteerRepository;
        private VolunteerServiceOperations volunteerServiceOperations;
        public VolunteerService(IVolunteerRepository volunteerRepository) 
        {
            this.volunteerRepository = volunteerRepository;
            volunteerServiceOperations = new VolunteerServiceOperations();
        }

        public async Task<List<DtoVolunteer>> GetAllVolunteersAsync()
        {
            var volunteers = await volunteerRepository.GetVolunteersAsync();
            return volunteerServiceOperations.ConvertToDTOList(volunteers);
           
        }

        public async Task<Volunteer> GetVolunteerByFullNameAsync(string firstName, string lastName)
        {
            return await volunteerRepository.GetVolunteerByFullNameAsync(firstName, lastName);
        }
        
        
        

    }
}
