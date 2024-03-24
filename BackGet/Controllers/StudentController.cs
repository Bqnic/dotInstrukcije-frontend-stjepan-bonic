using BackGet.Models;
using BackGet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [ApiController]
    public class StudentController : Controller {
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository) {
            _studentRepository = studentRepository;            
        }

        [HttpGet("students")]
        public IActionResult GetStudents(){
            var students = _studentRepository.GetStudents();

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            return Ok(students);
        }

        [HttpGet("student/{email}")]
        public IActionResult GetStudentByEmail([FromRoute] string email){
            var student = _studentRepository.getStudentByEmail(email);

            if (student == null){
                return NotFound();
            }

            return Ok(student);
        }
    }    
}