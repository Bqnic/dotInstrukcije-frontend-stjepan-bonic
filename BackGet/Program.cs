using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BackGet.Data;

namespace BackGet
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            SetUpDB(builder);

            var app = builder.Build();

            TestDatabaseConnection(app.Services);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

            
        }
         private static void SetUpDB(WebApplicationBuilder builder) {
            builder.Services.AddDbContext<DBContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        }

        private async static void TestDatabaseConnection(IServiceProvider services) {
            await Task.Delay(3000);

            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
            try
            {
                dbContext.Database.OpenConnection();
                dbContext.Database.CloseConnection();
                Console.WriteLine("Database connection successful.");
                foreach (var user in dbContext.Users.ToList())
                {
                    Console.WriteLine($"Name: {user.Name}, Username: {user.Username}, ID: {user.ID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
            }
        }
    }
}