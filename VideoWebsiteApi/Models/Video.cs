using System.ComponentModel.DataAnnotations;

namespace VideoWebsiteApi.Models
{
    public class Video
    {
        [Key] // 主键
        public int VideoId { get; set; }

        [Required] // 必须项
        [StringLength(100)] // 标题的最大长度
        public string Title { get; set; }

        [StringLength(500)] // 描述的最大长度
        public string Description { get; set; }
       
        public DateTime PostedOn { get; set; }
        
        public TimeSpan Duration { get; set; }

        [StringLength(50)] // 发布者的名字最大长度
        public string Poster { get; set; }

        public string VideoFilePath { get; set; }

        public string ThumbnailsPath { get; set; }
    }
}
