using StudentAdminPortal.API.DomainModels;
using VolunteersManagement.API.Models;
using VolunteersManagement.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VolunteersManagement.API.Services
{
    public class StudentService
    {

        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            this.studentRepository = studentRepository;
        }
        public async Task<List<DtoVolunteer>> GetAllStudentAsync()
        {
            var volunteers = await studentRepository.GetVolunteersAsync();
            var dtoVolunteersList = new List<DtoVolunteer>();
            foreach (var volunteer in volunteers)
            {
                dtoVolunteersList.Add(ConvertToDto(volunteer));
            }
            return dtoVolunteersList;
        }
        private DtoVolunteer ConvertToDto(Volunteer volunteer)
        {
            return new DtoVolunteer()
            {
                Id = volunteer.Id,
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                DateOfBirth = volunteer.DateOfBirth,
                Email = volunteer.Email,
                ProfileImageUrl = volunteer.ProfileImageUrl,
                Gender = volunteer.Gender
            };
        }

    }
}
