import { CommonModule } from '@angular/common';
import { Component,OnInit} from '@angular/core';
import { HttpClient,HttpClientModule } from '@angular/common/http';
import { VideoService} from '../testhttp/test.service';
import { Video } from '../models/video.model';
@Component({
  selector: 'app-testhttp',
  standalone: true,
  imports: [CommonModule,HttpClientModule],
  providers: [VideoService,HttpClient],
  templateUrl: './testhttp.component.html',
  styleUrl: './testhttp.component.css'
})
export class TesthttpComponent{
  videos: Video[] = [];

  constructor(private readonly videoService: VideoService) { }

  ngOnInit(): void {
    this.videoService.getVideos().subscribe(videos => this.videos = videos);
  }
}
