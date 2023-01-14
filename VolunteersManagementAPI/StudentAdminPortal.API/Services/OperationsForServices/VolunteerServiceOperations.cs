using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public class VolunteerServiceOperations
    {

        
        public DtoVolunteer ConvertToDto(Volunteer volunteer)
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
