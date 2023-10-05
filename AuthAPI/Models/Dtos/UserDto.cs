namespace AuthAPI.Models.Dtos
{
    public class UserDto
    {
        // IDs in Identity are Guids so it must be a string here
        public string Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
