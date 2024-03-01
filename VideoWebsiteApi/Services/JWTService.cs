using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VideoWebsiteApi.Interfaces;
using VideoWebsiteApi.Models;
namespace VideoWebsiteApi.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJWT(User user)
        {
            // 从配置文件读取秘钥、发行人和受众
            var secret = _configuration.GetValue<string>("JwtConfig:Secret");
            var issuer = _configuration.GetValue<string>("JwtConfig:Issuer");
            var audience = _configuration.GetValue<string>("JwtConfig:Audience");

            // 从十六进制字符串转换为字节
            byte[] keyBytes = Convert.FromHexString(secret);

            // 创建Claims数组
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()), // 用户的唯一标识
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username), // 用户的用户名
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT的唯一标识
            // 可以添加更多的Claims
        };

            // 创建加密的密钥
            var key = new SymmetricSecurityKey(keyBytes);

            // 创建签署凭证
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 定义JWT的过期时间
            var expires = DateTime.Now.AddDays(7);

            // 创建JWT
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            // 序列化JWT为字符串
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
