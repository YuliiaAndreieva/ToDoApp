import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-password-input',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './password-input.component.html',
})
export class PasswordInputComponent {
  @Input() password: string = '';
}
