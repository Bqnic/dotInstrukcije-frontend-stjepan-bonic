using BackGet.Utils;
using BackGet.Repository;
using BackGet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BackGet.Models;

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

        [HttpPost("/register/student")]
        public IActionResult RegisterStudent([FromForm] StudentRegistration studentRegistration){
            if (!studentRegistration.Password.Equals(studentRegistration.ConfirmPassword)){
                ModelState.AddModelError("", "Password doesn't match");
                return BadRequest(ModelState);
            }
            if (!RegexUtils.IsValidEmail(studentRegistration.Email)){
                ModelState.AddModelError("", "Email isn't valid");
                return BadRequest(ModelState);
            }
            if (_studentRepository.getStudentByEmail(studentRegistration.Email) != null){
                ModelState.AddModelError("", "Student with this email already exists.");
                return BadRequest(ModelState);
            }
            
            var student = new Student
            {
                Name = studentRegistration.Name,
                Surname = studentRegistration.Surname,
                Email = studentRegistration.Email,
                Password = studentRegistration.Password,
                ProfilePictureUrl = studentRegistration.ProfilePicture ?? null,
            };

            if(!_studentRepository.AddStudent(student)){
                ModelState.AddModelError("", "Something went wrong");
                return BadRequest(ModelState);
            }
                
            return CreatedAtAction(nameof(RegisterStudent), student);
        }
    }    
}