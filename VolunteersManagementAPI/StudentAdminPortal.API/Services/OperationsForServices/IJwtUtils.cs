using System;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
