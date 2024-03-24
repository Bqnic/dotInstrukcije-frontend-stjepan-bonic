using BackGet.Data;
using BackGet.Models;

namespace BackGet.Repository {
    public class ProfessorRepository {
        private readonly DBContext _context;
        public ProfessorRepository(DBContext context) {
            _context = context;
        }

        public ICollection<Professor> GetProfessors(){
            return _context.Professor.ToList();
        }

        public Professor GetProfessorByEmail(string email){
            return _context.Professor.FirstOrDefault(professor => professor.Email == email);
        }
    }
    
}