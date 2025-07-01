using Employment_Counseling.Entities;

namespace Employment_Counseling.DTOs
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public Object? User { get; set; }
        public bool IsCostumer {  get; set; }
        public bool IsNewUser {  get; set; }

        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public static LoginResult Fail(string error) => new() { Success = false, ErrorMessage = error };
        public static LoginResult Ok(Object user,string token, string refreshToken, bool isCostumer, bool isNewUser = false) => new() 
        {
            Success = true,
            User = user ,
            Token = token,
            RefreshToken = refreshToken,
            IsCostumer = isCostumer,
            IsNewUser = isNewUser
        };
    }
}
