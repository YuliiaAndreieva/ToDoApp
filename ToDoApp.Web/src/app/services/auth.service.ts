import { Injectable } from '@angular/core';
import { API_URLS } from '../shared/constants';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { UserAuthModel } from '../models/user/user.auth.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}

  register(registerData: UserAuthModel): Observable<any> {
    const body = { registerData };
    return this.http.post(API_URLS.AUTH.REGISTER, body);
  }

  login(loginData: UserAuthModel): Observable<any> {
    return this.http.post(API_URLS.AUTH.LOGIN, loginData).pipe(
      map((response: any) => {
        if (response.token) {
          localStorage.setItem('token', response.token);
        }
        return response;
      }),
    );
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
