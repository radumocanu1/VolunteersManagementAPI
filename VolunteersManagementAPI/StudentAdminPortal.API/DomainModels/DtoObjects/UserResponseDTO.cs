using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.DomainModels.DtoObjects
{
    public class UserResponseDTO
    {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public UserResponseDTO(User user, string token) {

            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
        

    }
}
