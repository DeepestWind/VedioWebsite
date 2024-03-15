import { Component, inject } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],//响应式表单模块
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup = new FormGroup({
    'username': new FormControl(null, Validators.required),
    'password': new FormControl(null, Validators.required)
  });

  constructor(private userService: UserService,
    private router: Router,
    private http: HttpClient,
    private snackBar: MatSnackBar
    ) { }

  ngOnInit(): void {
    console.log(this.loginForm.controls['username'].value);
  }

  onSubmit() {
    if (this.loginForm.invalid) {
      this.snackBar.open('Please check your input!', 'Close', {
        duration: 2000,
      });
      return;
    } 
    //console.log("onSubmit is working")
    const val = this.loginForm.value;

    this.userService.login(val.username, val.password)
      .subscribe(
        (data) => {
          //console.log("User is logged in");
          localStorage.setItem('token', data.token);
          this.router.navigateByUrl('/');
          this.snackBar.open('Log in successful!', 'Close', {
            duration: 3000
          });
        },
        (error) => {
          this.snackBar.open('Invalid username or password!', 'Close', {
            duration: 2000,
          });
        }
      );
  }
}
