using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public class VolunteerServiceOperations
    {

        public List<DtoVolunteer> ConvertToDTOList(List<Volunteer> volunteers)
        {
            var dtoVolunteersList = new List<DtoVolunteer>();
            foreach (var volunteer in volunteers)
            {
                dtoVolunteersList.Add(ConvertToDto(volunteer));
            }
            return dtoVolunteersList;
        }
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

        internal Task<DtoVolunteer> ConvertToDto(object value)
        {
            throw new NotImplementedException();
        }
    }
}
