using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VolunteersManagement.API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid VolunteerId { get; set; }
    }
}