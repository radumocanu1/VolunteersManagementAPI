using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VolunteersManagement.API.Services.OperationsForServices;
using System;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.DomainModels.UpdateObjects;
using System.Diagnostics;

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

        public System.Threading.Tasks.Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DtoVolunteer>> GetAllVolunteersAsync()
        {
            var volunteers = await volunteerRepository.GetVolunteersAsync();
            return ConvertToDTOList(volunteers);
           
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
        public async Task<DtoVolunteer> UpdateVolunteerByIdAsync(Guid volunteerId, UpdateVolunteer updateVolunteer)
        {
             
            if (await volunteerRepository.Exist(volunteerId))
            {
                var updatedVolunteer = await volunteerRepository.updateVolunteerAsync(await ConvertToVolunteer(volunteerId, updateVolunteer));
                return volunteerServiceOperations.ConvertToDto(updatedVolunteer);
            }
            return null;
        }
        private List<DtoVolunteer> ConvertToDTOList(List<Volunteer> volunteers)
        {
            var dtoVolunteersList = new List<DtoVolunteer>();
            foreach (var volunteer in volunteers)
            {
                dtoVolunteersList.Add(volunteerServiceOperations.ConvertToDto(volunteer));
            }
            return dtoVolunteersList;
        }

        private async Task<Volunteer> ConvertToVolunteer(Guid id, UpdateVolunteer updateVolunteer)
        {
            return new Volunteer()
            {
                Id = id,
                GenderId = updateVolunteer.GenderId,
                Gender = await volunteerRepository.GetGenderByIdAsync(updateVolunteer.GenderId),
                FirstName = updateVolunteer.FirstName,
                LastName = updateVolunteer.LastName,
                Email = updateVolunteer.Email,
                PhoneNumber = updateVolunteer.PhoneNumber,
                DateOfBirth = DateTime.Parse(updateVolunteer.DateOfBirth),
                Address = null,
                ProfileImageUrl = updateVolunteer?.ProfileImageUrl,
            };
        }


    }
}
