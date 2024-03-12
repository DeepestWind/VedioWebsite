import { Component, inject } from '@angular/core';
import { Video } from '../models/video.model';
import { ActivatedRoute } from '@angular/router';
import { VideoService } from '../services/video.service';
@Component({
  selector: 'app-video-detail',
  standalone: true,
  imports: [],
  templateUrl: './video-detail.component.html',
  styleUrl: './video-detail.component.css'
})
export class VideoDetailComponent {
  //使用inject装饰器注入服务
  //等效于constructor(private route: ActivatedRoute)
  route: ActivatedRoute = inject(ActivatedRoute);
  videoService: VideoService = inject(VideoService);
  video: Video | undefined;

  constructor() {
    const videoId = Number(this.route.snapshot.paramMap.get('id'));//也可以使用snapshot.params['id']
    this.videoService.getVideoById(videoId).subscribe({
      next: (v) => {
        this.video = v;
      },
      // 这里可以处理错误，例如视频不存在或服务无响应等
      error: (e) => {
        console.error('Error loading video', e);
      }
    });
   }

}
