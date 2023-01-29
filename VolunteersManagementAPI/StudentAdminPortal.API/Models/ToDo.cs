using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VolunteersManagement.API.Models
{
    public class ToDo
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        [JsonIgnore]
        public ICollection<ManyToMany> manyToMany { get; set; }

    }
}
