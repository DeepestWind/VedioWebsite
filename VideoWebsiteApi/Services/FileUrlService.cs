using VideoWebsiteApi.Interfaces;
namespace VideoWebsiteApi.Services
{
    public class FileUrlService : IFileUrlService
    {
        private readonly string _baseUrl;
        public FileUrlService(IConfiguration config) 
        {
            _baseUrl = config.GetValue<string>("BaseUrl");
        }
        public string GetFullUrl(string relativePath)
        {
            return $"{_baseUrl}/resources/{relativePath}";
        }
    }
}
