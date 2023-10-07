using AuthAPI.Models;

namespace AuthAPI.Services.IServices
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public string GenerateToken(ApplicationUser applicationUser)
        {
            
        }
    }
}
