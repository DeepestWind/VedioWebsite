import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
  
})
export class VideoService {
  private apiURL = 'https://localhost:7206/api/videos'; // 替换为您的 Web API 地址

  constructor(private http: HttpClient) { }

  getVideos(): Observable<any> {
    return this.http.get(this.apiURL);
  }

  // 其他与 API 通信的方法...
}