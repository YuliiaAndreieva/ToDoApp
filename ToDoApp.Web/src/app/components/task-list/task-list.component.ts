import { Component, OnInit } from '@angular/core';
import { TaskModel } from '../../models/task/task.model';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TaskService } from '../../services/task.service';
import { NgClass, NgForOf, NgIf } from '@angular/common';
import { CategoryModel } from '../../models/category/category.model';
import { CategoryService } from '../../services/category.service';
import { PaginationComponent } from '../pagination/pagination.component';
import { PaginationModel } from '../../models/pagination.model';
import { Router, RouterLink } from '@angular/router';
import { CategorySelectorComponent } from '../category-selector/category-selector.component';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgForOf,
    FormsModule,
    NgIf,
    NgClass,
    PaginationComponent,
    RouterLink,
    CategorySelectorComponent,
  ],
  templateUrl: './task-list.component.html',
})
export class TaskListComponent implements OnInit {
  tasks: TaskModel[] = [];
  availableCategories: CategoryModel[] = [];
  selectedCategories: CategoryModel[] = [];
  pagination: PaginationModel = {
    totalCount: 0,
    pageSize: 10,
    currentPage: 1,
    totalPages: 0,
    hasNextPage: false,
    hasPreviousPage: false,
  };

  isDropdownOpen = false;
  searchTerm: string = '';
  currentPage: number = 1;

  constructor(
    private taskService: TaskService,
    private categoryService: CategoryService,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.loadTasks();
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService
      .getCategories()
      .subscribe((categories: CategoryModel[]) => {
        this.availableCategories = categories;
      });
  }

  loadTasks(): void {
    const request = {
      CategoryIds:
        this.selectedCategories.length > 0
          ? this.selectedCategories.map((category) => category.id)
          : undefined,
      SearchTerm: this.searchTerm || undefined,
      Page: this.currentPage,
    };
    console.log('request', request);
    this.taskService.getPagedTasks(request).subscribe((response) => {
      this.tasks = response.items;
      this.pagination = {
        totalCount: response.totalCount,
        pageSize: response.pageSize,
        currentPage: response.page,
        hasNextPage: response.hasNextPage,
        hasPreviousPage: response.hasPreviousPage,
        totalPages: 1,
      };
      console.log('response', response);
    });
  }

  onSearchChange(): void {
    this.currentPage = 1;
    this.loadTasks();
  }

  onPageChange(newPage: number): void {
    this.currentPage = newPage;
    this.loadTasks();
  }

  onCategoriesChanged(selectedCategories: CategoryModel[]): void {
    this.selectedCategories = selectedCategories;
    this.currentPage = 1;
    this.loadTasks();
  }
  onUpdateTask(task: TaskModel) {
    this.router.navigate(['/task-update', task.id]);
  }
}
