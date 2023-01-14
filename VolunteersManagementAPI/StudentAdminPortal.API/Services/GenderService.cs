using System.Collections.Generic;
using System.Threading.Tasks;
using VolunteersManagement.API.DomainModels;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services.OperationsForServices;

namespace VolunteersManagement.API.Services
{
    public class GenderService
    {
        private GenderServiceOperations genderServiceOperations;
        private readonly IVolunteerRepository volunteerRepository;
        public GenderService(IVolunteerRepository volunteerRepository) {
            this.volunteerRepository = volunteerRepository;
            this.genderServiceOperations= new GenderServiceOperations();
        }
        public async Task<List<DtoGender>> GetGendersAsync()
        {
            var genders = await volunteerRepository.GetGendersAsync();
            return ConvertToDtoList(genders);

        }
        private List<DtoGender> ConvertToDtoList(List<Gender> genders)
        {
            var dtoGenders = new List<DtoGender>();
            foreach (var gender in genders)
            {
                dtoGenders.Add(genderServiceOperations.ConvertToDto(gender));
            }
            return dtoGenders;
        }
    }
}
