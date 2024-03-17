using Microsoft.EntityFrameworkCore;
using BackGet.Models;
namespace BackGet.Data{
    public class DBContext : DbContext{
        public DBContext(DbContextOptions<DBContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(@"Data Source=/home/bonic/Documents/sqlite/dotget.db");
        }
        public DbSet<User> Users { get; set; }
    }
}