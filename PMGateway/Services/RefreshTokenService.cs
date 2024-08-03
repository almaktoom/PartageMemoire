using PMGateway.Model;

namespace PMGateway.Services
{
    public class RefreshTokenService
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public RefreshTokenService()
        {
        }

        public RefreshToken GetStoredRefreshToken(string refreshToken)
        {
            return _context.RefreshTokens.SingleOrDefault(rt => rt.Token == refreshToken);
        }

        public void SaveRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Update(refreshToken);
            _context.SaveChanges();
        }

        public void AddRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);
            _context.SaveChanges();
        }
    }

}
