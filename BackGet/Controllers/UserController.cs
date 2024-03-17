using BackGet.Data;
using BackGet.Models;
using BackGet.Utils;
using BackGet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackGet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DBContext context;

        public UsersController(DBContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name,
                    Username = model.Username,
                    Email = model.Email,
                    Password = PasswordUtils.HashPassword(model.Password)
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                var response = new { success = true, user };
                return Ok(response);
            }

            return BadRequest(ModelState);
        }
    }
}