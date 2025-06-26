using Employment_Counseling.Entities.Enums;

namespace Employment_Counseling.Entities
{
    public class AuthToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }  

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ExpiresAt { get; set; } 

        public bool IsUsed { get; set; } = false; 

        public TokenType Type { get; set; }
    }

}
