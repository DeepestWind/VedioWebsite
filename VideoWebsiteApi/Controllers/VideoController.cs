using Microsoft.AspNetCore.Mvc;
using VideoWebsiteApi.Models;
using Microsoft.Extensions.Configuration;
using VideoWebsiteApi.Services;
using VideoWebsiteApi.Interfaces;
using VideoWebsiteApi.Data;
namespace VideoWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IFileUrlService _fileUrlService;
        private readonly ApplicationDbContext _context;
        public VideoController(IFileUrlService fileUrlService,ApplicationDbContext context)
        {
            _fileUrlService = fileUrlService;
            _context = context;
            //模拟的数据库中存储的数据格式
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> GetAllVideos()
        {
            // 从数据库获取视频信息
            var videos = _context.Videos.ToList();
            foreach (var video in videos)
            {
                //调用服务拼接完整的url
                video.ThumbnailsPath = _fileUrlService.GetFullUrl(video.ThumbnailsPath);
                video.VideoFilePath = _fileUrlService.GetFullUrl(video.VideoFilePath);
            }

            return Ok(videos);
        }

        [HttpGet("{id}")]
        public ActionResult<Video> GetVideoById(int id)
        {
            // 从数据库中查找匹配ID的视频信息
            var video = _context.Videos.FirstOrDefault(v => v.VideoId == id);

            if (video == null)
            {
                // 如果没有找到视频，返回 NotFound
                return NotFound();
            }

            // 如果找到视频，调用服务拼接完整的url
            video.ThumbnailsPath = _fileUrlService.GetFullUrl(video.ThumbnailsPath);
            video.VideoFilePath = _fileUrlService.GetFullUrl(video.VideoFilePath);

            // 返回找到的视频
            return Ok(video);
        }

        // Later you can add more methods to handle POST, PUT, DELETE...
    }
}
