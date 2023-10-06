using AuthAPI.Data;
using AuthAPI.Models;
using AuthAPI.Models.Dtos;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var user = _db.ApplicationUsers.First(u => u.Email == loginRequestDto.Username);

                var isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (user == null || isValid == false)
                {
                    return new LoginResponseDto { User = null, Token = "" };
                }

                UserDto userDto = new()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                };

                LoginResponseDto loginResponse = new()
                {
                    User = userDto,
                    Token = ""
                };

                return loginResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser userToBeCreated = new()
            {
                Email = registrationRequestDto.Email,
                UserName = registrationRequestDto.Username,
                Name = registrationRequestDto.Name

            };

            try
            {
                var result = await _userManager.CreateAsync(userToBeCreated);

                if (result.Succeeded)
                {
                    // In case, we need this later
                    var user = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
                

                

            }
            catch (Exception e)
            {
                
            }

            return "Error Encountered";
        }
    }
}
