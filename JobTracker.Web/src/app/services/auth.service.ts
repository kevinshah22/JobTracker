import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../Models/api-response.model';
import { LoginResponse } from '../Models/login-response.model';
import {UserLoginModel} from '../Models/login-request.model'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7150/api/auth/login'; // 🔁 Replace with your actual API


  constructor(private http: HttpClient) {}

  login(data: UserLoginModel): Observable<boolean> {
    
    return this.http.post<ApiResponse<LoginResponse>>(this.apiUrl, data).pipe(
      map(response => {
        // Save token to localStorage or a service for future API calls
        if(response.statusCode == 200)
        {
          localStorage.setItem('auth_token', response.result.token);
          //localStorage.setItem('user', JSON.stringify(response.user));
          return true;
        }
        return false;
      })
    );
  }

  logout(): void {
    localStorage.removeItem('auth_token');
    localStorage.removeItem('user');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('auth_token');
  }

  getToken(): string | null {
    return localStorage.getItem('auth_token');
  }
}
