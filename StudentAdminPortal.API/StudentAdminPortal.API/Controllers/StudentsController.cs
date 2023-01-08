using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Repositories;
using StudentAdminPortal.API.Services;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;

        private StudentService studentService;

        public StudentsController(IStudentRepository studentRepository)
        {
          this.studentService = new StudentService(studentRepository);
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            return Ok( await studentService.GetAllStudentAsync());
        }
    }
}
