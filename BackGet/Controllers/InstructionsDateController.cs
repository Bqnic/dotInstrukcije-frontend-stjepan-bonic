using BackGet.Models;
using BackGet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsDateController : Controller{
        private readonly InstructionsDateRepository _instructionsDateRepository;
        public InstructionsDateController(InstructionsDateRepository instructionsDateRepository) {
            _instructionsDateRepository = instructionsDateRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InstructionsDate>))]
        public IActionResult GetSubjects() {
            var instructionsDates = _instructionsDateRepository.GetInstructionsDates();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(instructionsDates);
        }
    }
    
}