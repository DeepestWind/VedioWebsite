import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Video } from '../models/video.model';

@Injectable({
  providedIn: 'root'
})
export class VideoService {
  private apiURL = 'https://localhost:7167/api/Video'; // 替换为您的 Web API 地址

  constructor(private readonly http: HttpClient) { }

  getVideos(): Observable<Video[]> {
    return this.http.get<Video[]>(this.apiURL);
  }

  // 根据视频ID获取单个视频的方法
  getVideoById(id: number): Observable<Video> {
    const url = `${this.apiURL}/${id}`;
    return this.http.get<Video>(url);
  }

  // 其他与 API 通信的方法...
}