using Microsoft.EntityFrameworkCore;
using VideoWebsiteApi.Data;
using VideoWebsiteApi.Interfaces;
using VideoWebsiteApi.Models;

namespace VideoWebsiteApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHashingService _hashingService;
        private readonly IJWTService _jwtService;

        public UserService(ApplicationDbContext context, IHashingService hashingService, IJWTService jwtService)
        {
            _context = context;
            _hashingService = hashingService;
            _jwtService = jwtService;
        }

        public async Task<User> Register(User user)
        {
            // 检查用户名或电子邮件是否已存在
            bool userExists = await _context.Users.AnyAsync(x => x.Username == user.Username ||
                                                                  x.Email == user.Email);
            if (userExists)
            {
                return null;
            }

            // 哈希密码
            string hashedPassword = _hashingService.HashPassword(user, user.Password);
            user.Password = hashedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> Login(LoginRequest loginRequest)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginRequest.Username);
            if (user == null)
            {
                return null;
            }

            var passwordValid = _hashingService.VerifyPassword(user, user.Password, loginRequest.Password);
            if (!passwordValid)
            {
                return null;
            }

            // 生成JWT Token发给客户端
            var token = _jwtService.GenerateJWT(user);

            return token;
        }
    }
}
