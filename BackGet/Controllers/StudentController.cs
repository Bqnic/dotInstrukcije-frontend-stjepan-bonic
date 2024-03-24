using BackGet.Utils;
using BackGet.Repository;
using BackGet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BackGet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BackGet.Controllers {
    [ApiController]
    public class StudentController : Controller {
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository) {
            _studentRepository = studentRepository;            
        }

        [Authorize]
        [HttpGet("students")]
        public IActionResult GetStudents(){
            var students = _studentRepository.GetStudents();

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            return Ok(students);
        }

        [Authorize]
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

        [HttpPost("/login/student")]
        public IActionResult LoginStudent([FromBody] StudentLogin studentLogin){
            var student = _studentRepository.getStudentByEmail(studentLogin.Email);
            if (student == null){
                ModelState.AddModelError("", "This email doesn't exist");
                return BadRequest(ModelState);
            }
            if (student.Password != studentLogin.Password){
                ModelState.AddModelError("", "Wrong password");
                return BadRequest(ModelState);
            }

             var token = GenerateJwtToken(student);

             var response = new
            {
                success = true,
                message = "Login successful",
                student = new { student.Id, student.Name, student.Surname, student.Email },
                token
            };

            return Ok(response);
        }

        private string GenerateJwtToken(Student student)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f5e2570c-83e3-4d88-b1ff-74dc1e45bca7"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, student.Email),
                new Claim("Id", student.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }    
}