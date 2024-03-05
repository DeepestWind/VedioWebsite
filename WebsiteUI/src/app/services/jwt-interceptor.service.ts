import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptorService implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // 从存储中获取JWT token（localStorage/sessionStorage等）
        const token = localStorage.getItem('jwtToken');

        if (token) {
            // 如果token存在，将其添加到请求头
            const cloned = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + token)
            });

            return next.handle(cloned);
        } else {
            return next.handle(req);
        }
    }
}