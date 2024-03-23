using BackGet.Models;
using BackGet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller {
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository) {
            _studentRepository = studentRepository;            
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudents(){
            var students = _studentRepository.GetStudents();

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            return Ok(students);
        }
    }    
}