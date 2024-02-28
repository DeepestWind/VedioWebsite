using Microsoft.AspNetCore.Mvc;
using VideoWebsiteApi.Data;
using VideoWebsiteApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        public UserController(ApplicationDbContext context) 
        {
            _context = context;
        }
        // POST api/user/register
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            // 检查用户名或电子邮件是否已存在
            bool userExists = await _context.Users.AnyAsync(x => x.Username == user.Username || x.Email == user.Email);
            if (userExists)
            {
                return BadRequest("Username or email already exists.");
            }

            // 哈希密码（请用实际的哈希方法替换这里的示例）
            user.Password = HashPassword(user.Password);

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(new { user.UserId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 在实际应用中，请使用更强的密码哈希方法，而不是这里演示的简单哈希
        private string HashPassword(string password)
        {
            // 使用实际的密码哈希算法
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
        
        // POST api/user/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User loginRequest)
        {
            // 在这里，我们只是模拟登录过程。在实际应用中，您应该验证用户名和密码哈希值
            var user = await _context.Users
                                     .SingleOrDefaultAsync(u => u.Username == loginRequest.Username
                                                             && u.Password == HashPassword(loginRequest.Password));
            if (user == null)
            {
                return Unauthorized();
            }

            // 生成JWT Token发给客户端（此处省略了具体生成Token的代码）
            var token = "generated-jwt-token"; // 需要实现真正的Token生成逻辑
            return Ok(new { token = token });
        }
    }
}
