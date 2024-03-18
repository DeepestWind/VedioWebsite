import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup = new FormGroup({
    'username': new FormControl(null, Validators.required),
    'password': new FormControl(null, Validators.required),
    'email': new FormControl(null, [
      Validators.required,
      Validators.email,
    ]),
  });

  constructor(
    private userService: UserService,
    private router: Router,
    private http: HttpClient,
    private snackBar: MatSnackBar) {}


    onSubmit() {
      if (this.registerForm.invalid) {
        this.snackBar.open('Please check your input!', 'Close', {
          duration: 2000,
        });
        return;
      }
  
      const val = this.registerForm.value;
  
      this.userService.register(val.username, val.password, val.email)
        .subscribe({
          next: () => {
            this.router.navigateByUrl('/login');
            this.snackBar.open('Register successful, please log in!', 'Close', {
              duration: 3000
            });
          },
          error: (error) => {
            if (error.error instanceof ErrorEvent) {
              this.snackBar.open('Register failed, please check your network!', 'Close', {
                duration: 2000,
              });
            } else {
              this.snackBar.open('Register failed, please try again!', 'Close', {
                duration: 2000,
              });
            }
          }
        });
    }
}
