import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { ButtonComponent } from '../../shared/buttons/button/button.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserAuthModel } from '../../models/user/user.auth.model';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ButtonComponent, FormsModule, ReactiveFormsModule, RouterLink],
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
      (response) => {
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
