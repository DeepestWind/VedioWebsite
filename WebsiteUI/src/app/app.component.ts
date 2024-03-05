import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptorService } from './services/jwt-interceptor.service';
import { TesthttpComponent } from './testhttp/testhttp.component';
@Component({
  selector: 'app-root',
  standalone: true,
  providers: [
    { //添加Jwt拦截器
      //注意此时只有该组件即AppComponent才会应用该拦截器
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptorService,
      multi: true}
  ],
  imports: [CommonModule, RouterOutlet,HomeComponent,TesthttpComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'WebsiteUI';
}
