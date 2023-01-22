using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories.UserRepository
{
    public interface IUserRepository
    {
        User FindByUsername(string username);

        Task<List<User>> GetAllAsync();

        Task<User> getById(Guid id);

        Task<User> CreateAsync(User User);

        Task<List<User>> getUsersAsync();

        Task<User> getByIdString(String id);
    }
}
