using BackGet.Models;
using Microsoft.EntityFrameworkCore;

namespace BackGet.Data {
    public class DBContext : DbContext {
        public DBContext (DbContextOptions<DBContext> options) : base(options) {}
        public DbSet<Student> Students {get; set;}
        public DbSet<Professor> Professors {get; set;}
        public DbSet<Subject> Subjects {get; set;}
        public DbSet<InstructionsDate> InstructionsDates {get; set;}
    }
    
}