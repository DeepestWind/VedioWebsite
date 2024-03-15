import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  user = {
    username: '',
    password: '',
    email: ''
  };

  constructor(private http: HttpClient) {}

  onRegister() {
    this.http.post('/api/user/register', this.user)
    .subscribe({
      next: (response) => {
        console.log('注册成功',response);
      },
      error: (error) => {
        console.error('注册失败', error);
      }
    });
  }
}
