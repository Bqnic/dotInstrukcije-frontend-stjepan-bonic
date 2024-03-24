using BackGet.Data;
using BackGet.Models;
using BackGet.ViewModels;

namespace BackGet.Repository {
    public class SubjectRepository {
        private readonly DBContext _context;
        public SubjectRepository(DBContext context) {
            _context = context;
        }

       public ICollection<SubjectGet> GetSubjects() {
            return _context.Subject.Select(s => new SubjectGet { Title = s.Title, Url = s.Url, Description = s.Description }).ToList();
        }

        public Subject GetSubjectByTitle(string title){
            return _context.Subject.FirstOrDefault(subject => subject.Title == title);
        }
    }
    
}