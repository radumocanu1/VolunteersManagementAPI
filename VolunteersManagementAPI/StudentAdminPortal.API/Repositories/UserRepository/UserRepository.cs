using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels.DtoObjects;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly VolunteerManagementContext context;
        public UserRepository(VolunteerManagementContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            var createdUser = await context.AddAsync(user);
            await context.SaveChangesAsync();
            return createdUser.Entity;
            
        }

        public User FindByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }
        public async Task<User> getById(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Task<List<User>> getUsersAsync()
        {
            return await context.Users.ToListAsync();
        }
    }
}
