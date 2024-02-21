import { Component,OnInit} from '@angular/core';
import { HttpSharedModule } from '../http-client.shared';
import { VideoService} from '../testhttp/test.service'
@Component({
  selector: 'app-testhttp',
  standalone: true,
  imports: [],
  templateUrl: './testhttp.component.html',
  styleUrl: './testhttp.component.css'
})
export class TesthttpComponent implements OnInit{
  videos: any[] = [];

  constructor(private videoService: VideoService) { }

  ngOnInit(): void {
    this.videoService.getVideos().subscribe(
      data => {
        this.videos = data;
      },
      error => {
        console.error('Error fetching data: ', error);
      }
    );
  }
}
