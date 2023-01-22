using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Models.Enums;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Repositories.UserRepository;
using VolunteersManagement.API.Services.OperationsForServices;

namespace VolunteersManagement.API.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository repository;
        private IJwtUtils jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            this.repository = userRepository;
            this.jwtUtils = jwtUtils;
        }

        public UserResponseDTO Auth(UserRequestDTO userRequestDTO)
        {
            var user = this.repository.FindByUsername(userRequestDTO.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userRequestDTO.Password, user.PasswordHash))
            {
                return null;
            }

            var JwtToken = this.jwtUtils.GenerateJwtToken(user);
       
            return new UserResponseDTO(user, JwtToken);
        }

        public async Task<User> Create(UserRequestDTO userRequestDTO)
        {
            var userToCreate = new User
            {
                Username = userRequestDTO.Username,
                Email = userRequestDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequestDTO.Password),
                role = Roles.Admin
            };

            return await repository.CreateAsync(userToCreate);
           
        }
        public async Task<User> CreateUser(UserRequestDTO userRequestDTO)
        {
            var userToCreate = new User
            {
                Username = userRequestDTO.Username,
                Email = userRequestDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRequestDTO.Password),
                role = Roles.User
            };

            return await repository.CreateAsync(userToCreate);

        }




        public async Task<User> GetbyID(Guid id)
        {
            return await repository.getById(id);
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await repository.GetAllAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            var ListOfUsers = await repository.getUsersAsync();
            return ListOfUsers;
        }
    }
}
