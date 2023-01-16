using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.DomainModels.UpdateObjects;
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
                PhoneNumber= volunteer.PhoneNumber,
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                DateOfBirth = volunteer.DateOfBirth,
                Email = volunteer.Email,
                ProfileImageUrl = volunteer.ProfileImageUrl,
                Gender = volunteer.Gender
            };
        }

        public DtoVolunteerAdmin ConvertToDtoAdmin(Volunteer volunteer)
        {
            return new DtoVolunteerAdmin()
            {
                Id = volunteer.Id,
                PhoneNumber = volunteer.PhoneNumber,
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                DateOfBirth = volunteer.DateOfBirth,
                Email = volunteer.Email,
                ProfileImageUrl = volunteer.ProfileImageUrl,
                Gender = volunteer.Gender,
                Address= volunteer.Address
            };
        }

    }
}
