using BackGet.Repository;
using BackGet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller{
        private readonly ProfessorRepository _professorRepository;
        public ProfessorController(ProfessorRepository professorRepository) {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Professor>))]
        public IActionResult GetProfessors() {
            var professors = _professorRepository.GetProfessors();

            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            return Ok(professors);
        }
    } 
    
}