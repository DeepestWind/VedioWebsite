//基础url规则

import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class BaseUrlInterceptor implements HttpInterceptor {
  // 定义您的基础 URL
  private readonly baseUrl = 'https://api.example.com';

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // 如果请求的 URL 不是完整的 URL，则添加基础 URL
    if (!request.url.startsWith('http')) {
      const apiReq = request.clone({ url: `${this.baseUrl}/${request.url}` });
      return next.handle(apiReq);
    }
    return next.handle(request);
  }
}