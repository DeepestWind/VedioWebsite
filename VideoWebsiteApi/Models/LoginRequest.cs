namespace VideoWebsiteApi.Models
{
    public class LoginRequest
    //这是一个用于输入的模型,只需要用户名和密码登录不需要邮箱
    //模型只包含请求所需的数据，而不是数据库中的所有数据，也称为DTO数据传输对象（data transfer object）
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
