export interface Video {
    videoId: number;
    title: string;
    description: string;
    postedOn: Date; // 视频上传的日期和时间 
    duration: string; // 视频的持续时间 
    poster: string; // 视频的发布者 
    videoFilePath: string; // 视频文件的路径 
    thumbnailsPath: string; // 视频的缩略图路径
}