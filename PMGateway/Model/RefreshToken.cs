namespace PMGateway.Model
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
