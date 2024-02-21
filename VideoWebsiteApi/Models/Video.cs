namespace VideoWebsiteApi.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }//视频上传的日期和时间。
        public TimeSpan Duration { get; set; }//视频的持续时间。
        public string Poster { get; set; }//视频的发布者。
        public string VideoFilePath { get; set; }//视频文件的路径。
        public string ThumbnailsPath { get; set; }//视频的缩略图路径。
    }
}
