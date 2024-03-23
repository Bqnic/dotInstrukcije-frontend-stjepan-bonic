namespace BackGet.Models {
    public class Subject{
        public int Id {get; set;}
        public required string Title {get; set;}
        public required string Url {get; set;}
        public string? Description {get; set;}
    }
}