using BackGet.Models;
using BackGet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller{
        private readonly SubjectRepository _subjectRepository;
        public SubjectController(SubjectRepository subjectRepository) {
            _subjectRepository = subjectRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
        public IActionResult GetSubjects() {
            var subjects = _subjectRepository.GetSubjects();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(subjects);
        }
    }
    
}