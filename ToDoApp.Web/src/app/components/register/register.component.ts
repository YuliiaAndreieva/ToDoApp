import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { ButtonComponent } from '../../shared/components/button/button.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAuthModel } from '../../models/user/user.auth.model';
import { PasswordInputComponent } from '../../shared/components/password-input/password-input.component';
import { EmailInputComponent } from '../../shared/components/email-input/email-input.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    ButtonComponent,
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
    PasswordInputComponent,
    EmailInputComponent,
  ],
  templateUrl: './register.component.html',
})
export class RegisterComponent {
  registerData: UserAuthModel = { email: '', password: '' };

  constructor(
    private authService: AuthService,
    private router: Router,
  ) {}
  onRegister() {
    this.authService.authenticate(this.registerData, true).subscribe(
      () => {
        this.router.navigate(['/task-list']);
      },
      (error) => {
        this.router.navigate(['/error'], {
          queryParams: {
            message: 'Register failed: ' + error.message,
          },
        });
      },
    );
  }
}
