using BackGet.Models;
using BackGet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BackGet.Controllers {
    [ApiController]
    public class SubjectController : Controller{
        private readonly SubjectRepository _subjectRepository;
        public SubjectController(SubjectRepository subjectRepository) {
            _subjectRepository = subjectRepository;
        }

        [HttpGet("subjects")]
        public IActionResult GetSubjects() {
            var subjects = _subjectRepository.GetSubjects();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(subjects);
        }

        [HttpGet("subject/{title}")]
        public IActionResult GetSubjectByTitle([FromRoute] string title){
            var subject = _subjectRepository.GetSubjectByTitle(title);

            if (subject == null){
                return NotFound();
            }

            return Ok(subject);
        }
    }
    
}