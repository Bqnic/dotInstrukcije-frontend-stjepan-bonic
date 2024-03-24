using BackGet.Data;
using BackGet.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

builder.Services.AddDbContext<DBContext>(options => 
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

//Dependancy injections
builder.Services.AddScoped<StudentRepository, StudentRepository>();
builder.Services.AddScoped<ProfessorRepository, ProfessorRepository>();
builder.Services.AddScoped<SubjectRepository, SubjectRepository>();
builder.Services.AddScoped<InstructionsDateRepository, InstructionsDateRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();
app.Run();
