using System;

namespace VolunteersManagement.API.DomainModels
{
    public class DtoAddress
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid VolunteerId { get; set; }
    }
}
