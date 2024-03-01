using VideoWebsiteApi.Models;
namespace VideoWebsiteApi.Interfaces
{
    public interface IJWTService
    {
        string GenerateJWT(User user);
    }
}
