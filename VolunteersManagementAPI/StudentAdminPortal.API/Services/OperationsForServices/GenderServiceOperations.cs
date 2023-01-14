using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;

namespace VolunteersManagement.API.Services.OperationsForServices
{
    public class GenderServiceOperations
    {
       public DtoGender ConvertToDto(Gender gender)
        {
            return new DtoGender()
            {
                Description= gender.Description,
                Id=gender.Id,
            };
        }
    }
}
