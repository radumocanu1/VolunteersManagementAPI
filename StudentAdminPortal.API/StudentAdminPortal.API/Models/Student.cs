﻿using System;
using System.Net.Sockets;

namespace StudentAdminPortal.API.Models
{
    public class Student
    {
        public Guid Id { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }   
        public string PhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        public Guid GenderId { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
