import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { TaskService } from '../../services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgIf } from '@angular/common';
import { TaskModel } from '../../models/task/task.model';
import { CategorySelectorComponent } from '../category-selector/category-selector.component';
import { CategoryModel } from '../../models/category/category.model';
import { CategoryService } from '../../services/category.service';
import { AddEditTaskModel } from '../../models/task/add-edit-task.model';

@Component({
  selector: 'app-add-edit-task',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, CategorySelectorComponent],
  templateUrl: './add-edit-task.component.html',
})
export class AddEditTaskComponent implements OnInit {
  taskForm: FormGroup;
  taskId?: number;
  isUpdateMode = false;
  availableCategories: CategoryModel[] = [];
  selectedCategories: CategoryModel[] = [];

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService,
  ) {
    this.taskForm = this.fb.group({
      name: ['', Validators.required],
      description: [''],
      dueDate: ['', Validators.required],
      isDone: [false],
    });
  }

  ngOnInit(): void {
    this.loadAvailableCategories();
    this.taskId = this.route.snapshot.params['id'];

    if (this.taskId) {
      this.isUpdateMode = true;
      this.taskService.getTaskById(this.taskId).subscribe(
        (task: TaskModel) => {
          this.taskForm.patchValue(task);
          if (task.categoryDtos && task.categoryDtos.length > 0) {
            this.selectedCategories = task.categoryDtos;
          }
        },
        (error) => {
          this.router.navigate(['/error'], {
            queryParams: {
              message: 'Error loading tasks: ' + error.message,
            },
          });
        },
      );
    }
  }

  loadAvailableCategories() {
    this.categoryService.getCategories().subscribe((categories) => {
      this.availableCategories = categories;
    });
  }

  onCategoriesChanged(selectedCategories: CategoryModel[]): void {
    this.selectedCategories = selectedCategories;
  }

  onSubmit(): void {
    if (this.taskForm.invalid) {
      return;
    }

    const taskData: AddEditTaskModel = {
      name: this.taskForm.value.name,
      description: this.taskForm.value.description,
      isDone: this.taskForm.value.isDone,
      dueDate: this.taskForm.value.dueDate,
      categoryIds: this.selectedCategories.map((category) => category.id),
    };

    if (this.isUpdateMode && this.taskId) {
      this.taskService.updateTask(this.taskId, taskData).subscribe(
        () => {
          this.router.navigate(['/task-list']);
        },
        (error) => {
          this.router.navigate(['/error'], {
            queryParams: {
              message: 'Error updating task: ' + error.message,
            },
          });
        },
      );
    } else {
      this.taskService.createTask(taskData).subscribe(
        () => {
          this.router.navigate(['/task-list']);
        },
        (error) => {
          this.router.navigate(['/error'], {
            queryParams: {
              message: 'Error creating task: ' + error.message,
            },
          });
        },
      );
    }
  }
  onUndo() {
    if (this.isUpdateMode) {
      this.taskForm.reset();
    }
    this.router.navigate(['/task-list']);
  }

  onClear() {
    this.taskForm.reset();
    this.selectedCategories = [];
  }
}
