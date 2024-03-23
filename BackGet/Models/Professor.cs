using Microsoft.EntityFrameworkCore;

namespace BackGet.Models {
    [Keyless]
    public class Professor { 
        public required int Id {get; set;}
        public required string Email {get; set;}
        public required string Name {get; set;}
        public required string Surname {get; set;}
        public required string Password {get; set;}
        public string? ProfilePictureUrl {get; set;}
        public int InstructionsCount {get; set;}
        public required string Subjects {get; set;}
    }
}