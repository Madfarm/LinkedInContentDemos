using AuthAPI.Models.Dtos;

namespace AuthAPI.Services.IServices
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        public Task<string> Register(RegistrationRequestDto registrationRequestDto);
    }
}
