using BackGet.Models;
using BackGet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [ApiController]
    public class InstructionsDateController : Controller{
        private readonly InstructionsDateRepository _instructionsDateRepository;
        public InstructionsDateController(InstructionsDateRepository instructionsDateRepository) {
            _instructionsDateRepository = instructionsDateRepository;
        }

        [HttpGet("dates")]
        public IActionResult GetInstructionDates() {
            var instructionsDates = _instructionsDateRepository.GetInstructionsDates();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(instructionsDates);
        }
    }
    
}