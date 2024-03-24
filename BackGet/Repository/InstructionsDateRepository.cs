using BackGet.Data;
using BackGet.Models;

namespace BackGet.Repository {
    public class InstructionsDateRepository {
        private readonly DBContext _context;
        public InstructionsDateRepository(DBContext context) {
            _context = context;
        }

        public ICollection<InstructionsDate> GetInstructionsDates(){
            return _context.InstructionsDate.ToList();
        }
    }
    
}