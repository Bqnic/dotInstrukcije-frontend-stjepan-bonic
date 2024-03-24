using BackGet.Repository;
using BackGet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [ApiController]
    public class ProfessorController : Controller{
        private readonly ProfessorRepository _professorRepository;
        public ProfessorController(ProfessorRepository professorRepository) {
            _professorRepository = professorRepository;
        }

        [HttpGet("professors")]
        public IActionResult GetProfessors() {
            var professors = _professorRepository.GetProfessors();

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            return Ok(professors);
        }

        [HttpGet("professor/{email}")]
        public IActionResult GetProfessorByEmail([FromRoute] string email){
            var professor = _professorRepository.GetProfessorByEmail(email);

            if (professor == null){
                return NotFound();
            }

            return Ok(professor);
        }
    } 
    
}