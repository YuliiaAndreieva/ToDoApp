import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryService } from '../../services/category.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-category-add',
  standalone: true,
  imports: [NgIf, ReactiveFormsModule],
  templateUrl: './category-add.component.html',
})
export class CategoryAddComponent {
  categoryForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService,
    private router: Router,
  ) {
    this.categoryForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
    });
  }

  onSubmit() {
    if (this.categoryForm.valid) {
      this.categoryService.createCategory(this.categoryForm.value).subscribe(
        () => {
          this.router.navigate(['/task-list']);
        },
        (error) => {
          console.error('Error creating category', error);
        },
      );
    }
  }

  onUndo() {
    this.categoryForm.reset();
    this.router.navigate(['/task-list']);
  }
}
