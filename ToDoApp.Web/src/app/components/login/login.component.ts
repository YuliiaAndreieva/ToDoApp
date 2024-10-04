import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ButtonComponent } from '../../shared/buttons/button/button.component';
import { UserAuthModel } from '../../models/user/user.auth.model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink, ButtonComponent],
  templateUrl: './login.component.html',
})
export class LoginComponent {
  loginData: UserAuthModel = { email: '', password: '' };

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}

  onLogin() {
    this.authService.authenticate(this.loginData, false).subscribe(
      (response) => {
        console.log('Login successful', response);
        this.router.navigate(['/task-list']);
      },
      (error) => {
        console.error('Login failed', error);
      },
    );
  }
}
