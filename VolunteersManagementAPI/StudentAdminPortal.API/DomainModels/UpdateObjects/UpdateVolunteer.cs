using System;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.DomainModels.UpdateObjects
{
    public class UpdateVolunteer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }

        public string PhysicalAddress { get; set; }

        public string PostalAddress { get; set; }

        public Guid GenderId { get; set; }
    }
}
