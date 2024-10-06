import { Component, forwardRef, Input } from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  FormGroup,
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from '@angular/forms';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-email-input',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, NgIf],
  templateUrl: './email-input.component.html',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => EmailInputComponent),
      multi: true,
    },
  ],
})
export class EmailInputComponent implements ControlValueAccessor {
  @Input() form!: FormGroup;
  @Input() controlName!: string;

  onChange = (_: any) => {};
  onTouched = () => {};

  get control(): FormControl {
    return this.form.get(this.controlName) as FormControl;
  }

  writeValue(value: any): void {
    this.form.get(this.controlName)?.setValue(value);
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    if (isDisabled) {
      this.form.get(this.controlName)?.disable();
    } else {
      this.form.get(this.controlName)?.enable();
    }
  }

  protected readonly FormControl = FormControl;
}
