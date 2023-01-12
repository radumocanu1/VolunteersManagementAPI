using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VolunteersManagement.API.Services.OperationsForServices;
using System;
using Microsoft.AspNetCore.Http;

namespace VolunteersManagement.API.Services
{
    public class VolunteerService : IActionResult
    {

        private readonly IVolunteerRepository volunteerRepository;
        private VolunteerServiceOperations volunteerServiceOperations;
        public VolunteerService(IVolunteerRepository volunteerRepository) 
        {
            this.volunteerRepository = volunteerRepository;
            volunteerServiceOperations = new VolunteerServiceOperations();
        }

        public System.Threading.Tasks.Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
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
       public async Task<DtoVolunteer> GetVolunteerByIdAsync(Guid id)
        {
            var volunteer = await volunteerRepository.GetVolunteerByIdAsync(id);
            if (volunteer == null)
                return null;
            return volunteerServiceOperations.ConvertToDto(volunteer);
        }
        
        

    }
}
