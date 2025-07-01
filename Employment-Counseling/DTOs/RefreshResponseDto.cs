namespace Employment_Counseling.DTOs
{
    public class RefreshResponseDto
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public string? AccessToken { get; set; }
        public object? RefreshToken { get; set; }
        public static RefreshResponseDto Fail(string error) => new() { Success = false, ErrorMessage = error };
        public static RefreshResponseDto Ok(string token, string refreshToken) => new()
        {
            Success = true,
            AccessToken = token,
            RefreshToken = refreshToken           
        };
    }
}