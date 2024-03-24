using BackGet.Models;
using Microsoft.EntityFrameworkCore;

namespace BackGet.Data {
    public class DBContext : DbContext {
        public DBContext (DbContextOptions<DBContext> options) : base(options) {}
        public DbSet<Student> Student {get; set;}
        public DbSet<Professor> Professor {get; set;}
        public DbSet<Subject> Subject {get; set;}
        public DbSet<InstructionsDate> InstructionsDate {get; set;}
    }
    
}