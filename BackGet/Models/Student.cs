namespace BackGet.Models {
    public class Student {
        public int Id {get; set;}
        public required string Email {get; set;}
        public required string Name {get; set;}
        public required string Surname {get; set;}
        public required string Password {get; set;}
        public string? ProfilePictureUrl {get; set;}
    }
}