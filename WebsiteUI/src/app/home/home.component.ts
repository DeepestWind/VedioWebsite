import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { HeaderModule } from '../header/header.module';
import { HttpClientModule } from '@angular/common/http'; 
import { VideoService } from '../services/video.service';
import { Video } from '../models/video.model';
import { VideoCardComponent } from '../video-card/video-card.component';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,HttpClientModule,HeaderModule,VideoCardComponent],
  providers: [VideoService],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  videos: Video[] = [];

  constructor(private readonly videoService: VideoService) { }

  ngOnInit(): void {
    this.videoService.getVideos().subscribe(videos => this.videos = videos);
  }
}
