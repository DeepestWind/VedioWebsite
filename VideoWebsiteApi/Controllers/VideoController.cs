using Microsoft.AspNetCore.Mvc;
using VideoWebsiteApi.Models;

namespace VideoWebsiteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private List<Video> _videos;

        public VideoController()
        {
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
                VideoFilePath = "Path to video file 1",
                ThumbnailsPath = "Path to thumbnails 1"
            },
            new Video
            {
                VideoId = 2,
                Title = "Video Title 2",
                Description = "Video Description 2",
                PostedOn = DateTime.Now.AddDays(-5),
                Duration = TimeSpan.FromMinutes(98),
                Poster = "User 2",
                VideoFilePath = "Path to video file 2",
                ThumbnailsPath = "Path to thumbnails 2"
            },
        };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Video>> GetAllVideos()
        {
            return _videos;
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
