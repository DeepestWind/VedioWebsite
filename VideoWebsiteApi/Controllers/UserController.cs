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
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;

        }
        // POST api/user/register
        [HttpPost("register")]

        //用户注册
        public async Task<ActionResult> Register([FromBody] User user)
        {
            var createdUser = await _userService.Register(user);

            if (createdUser != null)
            {
                return Ok(new { UserId = createdUser.UserId });//返回一个用户ID
            }
            else
            {
                return BadRequest("Username or email already exists.");
            }
        }

        // POST api/user/login
        //使用单独用于输入输出的模型
        //DTO模式（data transfer mode）
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var token = await _userService.Login(loginRequest);

            if (token != null)
            {
                return Ok(new { token });
            }
            else
            {
                return BadRequest("Invalid username or password.");
            }
        }

    }
}
