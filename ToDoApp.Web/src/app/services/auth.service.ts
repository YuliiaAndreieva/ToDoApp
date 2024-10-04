import { Injectable } from '@angular/core';
import { API_URLS } from '../shared/constants';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, catchError, map, Observable, throwError } from 'rxjs';
import { UserAuthModel } from '../models/user/user.auth.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private authenticatedSubject = new BehaviorSubject<boolean>(
    this.isAuthenticated(),
  );
  public isAuthenticated$ = this.authenticatedSubject.asObservable();
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
          this.authenticatedSubject.next(true);
        }
        return response;
      }),
      catchError((error) => {
        this.authenticatedSubject.next(false);
        return throwError(error);
      }),
    );
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout(): void {
    localStorage.removeItem('token');
    this.authenticatedSubject.next(false);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
