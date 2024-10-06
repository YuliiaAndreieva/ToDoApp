import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export class CustomValidators {
  static nameLengthValidator(
    minLength: number,
    maxLength: number,
  ): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value as string;
      if (value && (value.length < minLength || value.length > maxLength)) {
        return { length: true };
      }
      return null;
    };
  }

  static dueDateValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const value = control.value;

      if (value) {
        const dueDate = new Date(value);
        const today = new Date();
        today.setHours(0, 0, 0, 0);

        if (dueDate < today) {
          return { invalidDate: true };
        }
      }

      return null;
    };
  }
}
