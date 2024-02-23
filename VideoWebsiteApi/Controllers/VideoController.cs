using Microsoft.AspNetCore.Mvc;
using VideoWebsiteApi.Models;
using Microsoft.Extensions.Configuration;
using VideoWebsiteApi.Services;
using VideoWebsiteApi.Interfaces;
namespace VideoWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private List<Video> _videos;
        private readonly IFileUrlService _fileUrlService;
        public VideoController(IFileUrlService fileUrlService)
        {
            _fileUrlService = fileUrlService;
            //模拟的数据库中存储的数据格式
            _videos = new List<Video>
        {
            new Video
            {
                VideoId = 1,
                Title = "Video Title 1",
                Description = "Video Description 1",
                PostedOn = DateTime.Now.AddDays(-10),
                Duration = TimeSpan.FromMinutes(125),
                Poster = "User 1",
                VideoFilePath = "1.mp4",
                ThumbnailsPath = "1.png"
            },
            new Video
            {
                VideoId = 2,
                Title = "Video Title 2",
                Description = "Video Description 2",
                PostedOn = DateTime.Now.AddDays(-5),
                Duration = TimeSpan.FromMinutes(98),
                Poster = "User 2",
                VideoFilePath = "2.mp4",
                ThumbnailsPath = "2.png"
            },
        };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> GetAllVideos()
        {

            foreach (var video in _videos)
            {
                //调用服务拼接完整的url
                video.ThumbnailsPath = _fileUrlService.GetFullUrl(video.ThumbnailsPath);
                video.VideoFilePath = _fileUrlService.GetFullUrl(video.VideoFilePath);
            }

            return Ok(_videos);
        }

        [HttpGet("{id}")]
        public ActionResult<Video> GetVideoById(int id)
        {
            var video = _videos.FirstOrDefault(v => v.VideoId == id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // Later you can add more methods to handle POST, PUT, DELETE...
    }
}
