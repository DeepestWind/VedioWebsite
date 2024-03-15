import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { VideoDetailComponent } from './video-detail/video-detail.component';
import { LoginComponent } from './login/login.component';
export const routes: Routes = [
    {
        path: '',
        component:HomeComponent,
        title: 'Home Page',
    },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'video/:id', component: VideoDetailComponent},
    
];

