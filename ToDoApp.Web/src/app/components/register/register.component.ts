import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router, RouterLink } from '@angular/router';
import { ButtonComponent } from '../../shared/components/button/button.component';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
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
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;

  constructor(
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder,
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(/[A-Z]/),
          Validators.pattern(/[0-9]/),
          Validators.pattern(/[^a-zA-Z0-9]/),
        ],
      ],
    });
  }

  onRegister() {
    const registerData = this.registerForm.value;
    this.authService.authenticate(registerData, true).subscribe(
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
