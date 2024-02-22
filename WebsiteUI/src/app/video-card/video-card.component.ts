import { Component,Input } from '@angular/core';
import { Video } from '../models/video.model';
@Component({
  selector: 'app-video-card',
  standalone: true,
  imports: [],
  templateUrl: './video-card.component.html',
  styleUrl: './video-card.component.css'
})
export class VideoCardComponent {
  @Input() video: Video ={
    videoId: 0,
    title: 'unfinded',
    description: 'unfinded',
    postedOn: new Date(),
    duration: 'unfinded',
    poster: 'unfinded',
    videoFilePath: 'unfinded',
    thumbnailsPath: 'unfinded'

  }
}
