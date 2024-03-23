using Microsoft.EntityFrameworkCore;

namespace BackGet.Models {
    [Keyless]
    public class InstructionsDate {
        public int StudentId {get; set;}
        public int ProfessorId {get; set;}
        public DateTime DateTime {get; set;}
        public string? Status {get; set;}
    }    
}