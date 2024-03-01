using Microsoft.AspNetCore.Identity;
using VideoWebsiteApi.Models;
using VideoWebsiteApi.Interfaces;
namespace VideoWebsiteApi.Services
{
    public class HashingService : IHashingService
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public HashingService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        // 如果未来您需要验证密码，您还可以使用如下方法：
        public bool VerifyPassword(User user, string hashedPassword, string providedPassword)
        {
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return verificationResult == PasswordVerificationResult.Success;
        }
    }
}
