namespace BackGet.ViewModels {
    public class StudentRegistration {
        public required string Name {get; set;}
        public required string Surname {get; set;}
        public required string Email {get; set;}
        public required string Password {get; set;}
        public required string ConfirmPassword {get; set;}
        public string? ProfilePicture {get; set;}
    }
}