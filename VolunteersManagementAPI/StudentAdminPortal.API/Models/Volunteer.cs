using System;
using System.Net.Sockets;
using System.Reflection;

namespace VolunteersManagement.API.Models
{
    public class Volunteer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        //this field should not be serialized
        public Guid GenderId { get; set; }
        public Gender Gender { get; set; }

        //this field should not be serialized ( configured custom dto object for this purpose)
        public Address Address { get; set; }
    }
}