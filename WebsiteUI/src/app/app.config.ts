import { ApplicationConfig,importProvidersFrom } from '@angular/core';
import { provideRouter,RouterModule,ActivatedRoute } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    //全局导入模块
    importProvidersFrom(HttpClientModule),
    importProvidersFrom(RouterModule),
    importProvidersFrom(ActivatedRoute)
  ]
};
