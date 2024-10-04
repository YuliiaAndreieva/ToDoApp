import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink, NgIf],
  templateUrl: './header.component.html',
})
export class HeaderComponent {
  isLoggedIn = false;

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {
    this.isLoggedIn = authService.isAuthenticated();
  }
  ngOnInit() {
    this.authService.isAuthenticated$.subscribe((isAuthenticated) => {
      this.isLoggedIn = isAuthenticated;
    });
  }

  onLogout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
