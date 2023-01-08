using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Services
{
    public class StudentService
    {

        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            this.studentRepository = studentRepository;
        }
        public async Task<List<DtoStudent>> GetAllStudentAsync()
        {
            var students = await studentRepository.GetStudentsAsync();
            var dtoStudentsList = new List<DtoStudent>();
            foreach (var student in students)
            {
                dtoStudentsList.Add(ConvertToDto(student));
            }
            return dtoStudentsList;
        }
        private DtoStudent ConvertToDto(Student student)
        {
            return new DtoStudent()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                ProfileImageUrl = student.ProfileImageUrl,
                Gender = student.Gender
            };
        }

    }
}
