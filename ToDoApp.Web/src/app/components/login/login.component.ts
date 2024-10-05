import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ButtonComponent } from '../../shared/components/button/button.component';
import { UserAuthModel } from '../../models/user/user.auth.model';
import { PasswordInputComponent } from '../../shared/components/password-input/password-input.component';
import { EmailInputComponent } from '../../shared/components/email-input/email-input.component';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    RouterLink,
    ButtonComponent,
    PasswordInputComponent,
    EmailInputComponent,
  ],
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
      () => {
        this.router.navigate(['/task-list']);
      },
      (error) => {
        this.router.navigate(['/error'], {
          queryParams: {
            message: 'Login is unsuccessful: ' + error.message,
          },
        });
      },
    );
  }
}
