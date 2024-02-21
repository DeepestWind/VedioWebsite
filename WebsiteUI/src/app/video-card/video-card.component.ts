import { Component } from '@angular/core';
import { Input } from '@angular/core';
@Component({
  selector: 'app-video-card',
  standalone: true,
  imports: [],
  templateUrl: './video-card.component.html',
  styleUrl: './video-card.component.css'
})
export class VideoCardComponent {
  @Input() video: any; // `any`可以替换为一个更加具体的视频类型接口
  navigateToVideoDetail(video: any) {
    // 这里替换为你的路由逻辑，可能会用到 Angular 的 Router
    // 例如: this.router.navigate(['/video', video.id]);
  }
}
