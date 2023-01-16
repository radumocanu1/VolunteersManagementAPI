using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using VolunteersManagement.API.Models.Enums;

namespace VolunteersManagement.API.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Roles role { get; set; }


        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
