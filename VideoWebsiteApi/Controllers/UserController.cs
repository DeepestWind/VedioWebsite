using Microsoft.AspNetCore.Mvc;
using VideoWebsiteApi.Data;
using VideoWebsiteApi.Models;
using System.Threading.Tasks;
using VideoWebsiteApi.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
namespace VideoWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //管理数据库连接
        private readonly ApplicationDbContext _context;
        private readonly IHashingService _hashingService;
        private readonly IJWTService _jwtService;

        public UserController(ApplicationDbContext context, IHashingService hashingService,IJWTService jwtService) 
        {
            _context = context;
            _hashingService = hashingService;
            _jwtService = jwtService;

        }
        // POST api/user/register
        [HttpPost("register")]

        //用户注册
        public async Task<ActionResult> Register([FromBody] User user)
        {
            // 检查用户名或电子邮件是否已存在
            bool userExists = await _context.Users.AnyAsync(x => x.Username == user.Username || x.Email == user.Email);
            if (userExists)
            {
                return BadRequest("Username or email already exists.");
            }

            // 哈希密码（请用实际的哈希方法替换这里的示例）
            string hashedPassword = _hashingService.HashPassword(user, user.Password);
            user.Password = hashedPassword;

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new { UserId = user.UserId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/user/login
        //使用单独用于输入输出的模型
        //DTO模式（data transfer mode）
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            // 在这里，我们验证用户名和校验密码
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginRequest.Username);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var passwordValid = _hashingService.VerifyPassword(user, user.Password, loginRequest.Password);
            if (!passwordValid)
            {
                return BadRequest("Invalid credentials.");
            }

            // 生成JWT Token发给客户端
            var token = _jwtService.GenerateJWT(user);

            return Ok(new { token });

        }
     
    }
}
