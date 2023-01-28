using System;

namespace VolunteersManagement.API.Models
{
    public class ManyToMany
    {
        public Guid VolunteerId { get; set; }
        public Volunteer volunteer { get; set; }

        public Guid ToDoId { get; set; }
        public ToDo toDo { get; set; }

    }
}
