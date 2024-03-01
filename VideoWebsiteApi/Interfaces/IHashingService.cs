using VideoWebsiteApi.Models;

namespace VideoWebsiteApi.Interfaces
{
    public interface IHashingService
    {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string providedPassword);
    }
}
