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

        public DbSet<User> Users { get; set; }

        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManyToMany>()
                .HasKey(mtm => new { mtm.VolunteerId, mtm.ToDoId});

            modelBuilder.Entity<ManyToMany>()
                .HasOne<Volunteer>(mtm => mtm.volunteer)
                .WithMany(v => v.manyToMany)
                .HasForeignKey(mtm => mtm.VolunteerId);


            modelBuilder.Entity<ManyToMany>()
               .HasOne<ToDo>(mtm => mtm.toDo)
               .WithMany(t => t.manyToMany)
               .HasForeignKey(mtm => mtm.ToDoId);

            base.OnModelCreating(modelBuilder);
            
        }


    }
}