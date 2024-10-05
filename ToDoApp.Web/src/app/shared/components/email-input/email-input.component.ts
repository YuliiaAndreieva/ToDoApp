import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-email-input',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './email-input.component.html',
})
export class EmailInputComponent {
  @Input() email: string = '';
}
