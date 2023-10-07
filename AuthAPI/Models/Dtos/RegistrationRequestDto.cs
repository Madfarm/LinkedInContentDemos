namespace AuthAPI.Models.Dtos
{
    public class RegistrationRequestDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
