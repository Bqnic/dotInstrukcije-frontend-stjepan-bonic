using BackGet.Data;
using BackGet.Models;

namespace BackGet.Repository {
    public class StudentRepository {
        private readonly DBContext _context;
        public StudentRepository(DBContext context) {
            _context = context;
        }

        public ICollection<Student> GetStudents(){
            return _context.Students.OrderBy(p => p.Id).ToList();
        }
    }
    
}