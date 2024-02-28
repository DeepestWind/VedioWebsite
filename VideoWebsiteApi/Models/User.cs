using System.ComponentModel.DataAnnotations;

namespace VideoWebsiteApi.Models
{
    public class User
    {
        [Key] // 这告诉EF Core这是主键
        public int UserId { get; set; }

        [Required] // 必须项
        [StringLength(50)] // 字符串长度限制
        public string Username { get; set; }

        [Required] // 密码也是必须项
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress] // 确保这是一个有效的电子邮件地址
        [StringLength(100)] // 字符串长度限制
        public string Email { get; set; }
    }
}
