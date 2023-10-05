namespace AuthAPI.Models.Dtos
{
    public class ResponseDto
    {
        // For the controller
        public bool IsSuccessful { get; set; } = true;
        public string Message { get; set; } = "";
        public object? Result { get; set; }
    }
}
