using BackGet.Data;
using BackGet.Models;

namespace BackGet.Repository {
    public class SubjectRepository {
        private readonly DBContext _context;
        public SubjectRepository(DBContext context) {
            _context = context;
        }

        public ICollection<Subject> GetSubjects() {
            return _context.Subject.ToList();
        }

        public Subject GetSubjectByTitle(string title){
            return _context.Subject.FirstOrDefault(subject => subject.Title == title);
        }
    }
    
}