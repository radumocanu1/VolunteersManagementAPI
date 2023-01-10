﻿using StudentAdminPortal.API.Models;
using System;

namespace StudentAdminPortal.API.DomainModels
{
    public class DtoStudent
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        public Gender Gender { get; set; }
    }
}
        