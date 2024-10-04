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

  authenticate(authData: UserAuthModel, isRegister: boolean): Observable<any> {
    const url = isRegister ? API_URLS.AUTH.REGISTER : API_URLS.AUTH.LOGIN;
    return this.http.post(url, authData).pipe(
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
