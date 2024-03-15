using VideoWebsiteApi.Models;
namespace VideoWebsiteApi.Interfaces
{
    public interface IUserService
    {

        Task<User> Register(User user);
        Task<string> Login(LoginRequest loginRequest);
    }
}
