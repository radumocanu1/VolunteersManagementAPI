using System;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Auth(UserRequestDTO userRequestDTO);
        Task<User> GetbyID(Guid id);
        Task<User> Create (UserRequestDTO userRequestDTO);

        UserResponseDTO Atuhentificate(UserRequestDTO model);


    }
}
