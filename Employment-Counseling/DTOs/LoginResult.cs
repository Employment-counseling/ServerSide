using Employment_Counseling.Entities;

namespace Employment_Counseling.DTOs
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public Object? User { get; set; }
        public bool IsCostumer {  get; set; }

        public string? Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
        public static LoginResult Fail(string error) => new() { Success = false, ErrorMessage = error };
        public static LoginResult Ok(Object user,bool isCostumer) => new() { Success = true, User = user , IsCostumer = isCostumer };
    }
}
