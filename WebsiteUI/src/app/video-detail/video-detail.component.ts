import { Component, OnDestroy, ViewChild, inject, ElementRef, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import videojs from 'video.js';
import Player from "video.js/dist/types/player";//这里不是很明白
import { Video } from '../models/video.model';
import { ActivatedRoute } from '@angular/router';
import { VideoService } from '../services/video.service';
import { HeaderModule } from '../header/header.module';
@Component({
  selector: 'app-video-detail',
  standalone: true,
  imports: [CommonModule,HeaderModule],
  templateUrl: './video-detail.component.html',
  styleUrl: './video-detail.component.css'
})
export class VideoDetailComponent implements OnInit{
  //使用inject装饰器注入服务
  //等效于constructor(private route: ActivatedRoute)
  route: ActivatedRoute = inject(ActivatedRoute);
  videoService: VideoService = inject(VideoService);
  video: Video | undefined;
  player: Player | undefined;

  @ViewChild('videoElement') videoElement?: ElementRef; //获取模板中的video元素引用

   ngOnInit(): void {
    const videoId = Number(this.route.snapshot.paramMap.get('id'));
    console.log('videoId:',videoId);
    this.videoService.getVideoById(videoId).subscribe({
      next: video => {
        this.video = video; // 保存视频数据，供后续使用
        this.initializePlayer();
        console.log('Video loaded:', this.video); // 用于调试
      },
      error: error => console.error('Error loading video', error)
    }); 
  }
  // 使用ngAfterViewInit确保视图完全初始化
  ngAfterViewInit(): void {
  }

  initializePlayer(): void {
    if (this.videoElement && this.video) {
        this.player = videojs(this.videoElement.nativeElement, {
          // 设置播放器的源，确保是在获取到视频路径后
          sources: [{
            src: this.video.videoFilePath,
            type: 'video/mp4' // 根据你的视频格式可能需要更改
          }],
          controls:true, //显示播放控制
          poster: this.video.thumbnailsPath, //缩略图路径
          perload:'auto',
          autoplay: false, // 设置为true将尝试自动播放视频
          // 在此处添加Video.js的其他选项
        }, function() {//回调函数，当player ready后会被调用
          //console.log('播放器已经准备好了!');
          //在此用来执行一些当播放器就绪后的操作
        });
      } else {
        console.error('视频路径未定义!');
      }
    }
  
  ngOnDestroy(): void {
    // 销毁播放器实例，避免内存泄漏
    if (this.player) {
      this.player.dispose();
      this.player = undefined;
    }
  }
}
