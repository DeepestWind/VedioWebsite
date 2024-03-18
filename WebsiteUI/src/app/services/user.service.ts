import { environment } from '../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private snackBar: MatSnackBar) { }

  login(username: string, password: string) {
    //console.log("logining")
    return this.http.post<any>(`${environment.apiUrl}/User/login`, {"username":username, "password":password})
    .pipe(
      catchError((error) => {
        this.snackBar.open('Login failed!', 'Close', {
          duration: 3000
        });
        throw error;
      })
    );
  }

  register(username: string, password: string, email: string) {
    return this.http.post<any>(`${environment.apiUrl}/User/register`, {"username":username, "password":password, "email":email})
    .pipe(
      catchError((error) => {
        this.snackBar.open('Register failed!', 'Close', {
          duration: 3000
        });
        throw error;
      })
    );
  }
}
