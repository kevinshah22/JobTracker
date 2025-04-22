import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../Models/api-response.model';
import { LoginResponse } from '../Models/login-response.model';
import { UserLoginModel } from '../Models/login-request.model'
import { environment } from "../../environment";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = `${environment.apiUrl}auth/login`

  //private apiUrl = 'https://localhost:7150/api/auth/login'; // 🔁 Replace with your actual API


  constructor(private http: HttpClient
  ) { }
  isBrowser(): boolean {
    return typeof window !== 'undefined';
  }

  login(data: UserLoginModel): Observable<boolean> {
    
    return this.http.post<ApiResponse<LoginResponse>>(this.apiUrl, data).pipe(
      map(response => {
        // Save token to localStorage or a service for future API calls
        if (response.statusCode == 200 && this.isBrowser() && response.result) {
          localStorage.setItem('auth_token', response.result.token);
          //localStorage.setItem('user', JSON.stringify(response.user));
          return true;
        }
        else {
          return false;
        }
      })
    );
  }

  logout(): void {
    if (this.isBrowser()) {
      localStorage.removeItem('auth_token');
    }
  }

  isLoggedIn(): boolean {
    return this.isBrowser() && !!localStorage.getItem('auth_token');

    //return !!localStorage.getItem('auth_token');
  }

  getToken(): string | null {
    return localStorage.getItem('auth_token');
  }
}
