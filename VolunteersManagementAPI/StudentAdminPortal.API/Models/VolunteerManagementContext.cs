using Microsoft.EntityFrameworkCore;

namespace VolunteersManagement.API.Models
{
    public class VolunteerManagementContext : DbContext
    {
        public VolunteerManagementContext(DbContextOptions<VolunteerManagementContext> options) : base(options)
        {

        }
        public DbSet<Volunteer> Volunteer { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }


    }
}