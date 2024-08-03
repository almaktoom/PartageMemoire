namespace PMGateway.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Stocker le hash du mot de passe
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } // Navigation vers les jetons d'actualisation


    }

}
