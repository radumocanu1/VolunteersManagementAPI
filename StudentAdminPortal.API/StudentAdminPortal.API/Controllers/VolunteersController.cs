using Microsoft.AspNetCore.Mvc;
using VolunteersManagement.API.Repositories;
using VolunteersManagement.API.Services;
using System.Threading.Tasks;

namespace VolunteersManagement.API.Controllers
{
    [ApiController]
    public class VolunteersController : Controller
    {
        private StudentService studentService;

        public VolunteersController(IStudentRepository studentRepository)
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
