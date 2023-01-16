using System.ComponentModel.DataAnnotations;

namespace VolunteersManagement.API.DomainModels.DtoObjects
{
    public class UserRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
