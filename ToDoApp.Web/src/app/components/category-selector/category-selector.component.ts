import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CategoryModel } from '../../models/category/category.model';
import { NgForOf, NgIf } from '@angular/common';

@Component({
  selector: 'app-category-selector',
  standalone: true,
  imports: [NgForOf, NgIf],
  templateUrl: './category-selector.component.html',
})
export class CategorySelectorComponent {
  @Input() availableCategories: CategoryModel[] = [];
  @Input() selectedCategories: CategoryModel[] = [];
  @Output() categoriesChanged = new EventEmitter<CategoryModel[]>();

  isDropdownOpen = false;

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  selectCategory(category: CategoryModel): void {
    const isSelected = this.selectedCategories.some(
      (selected) => selected.id === category.id,
    );

    if (!isSelected) {
      this.selectedCategories.push(category);
      this.categoriesChanged.emit(this.selectedCategories);
    }

    this.toggleDropdown();
  }

  removeCategory(category: CategoryModel): void {
    this.selectedCategories = this.selectedCategories.filter(
      (c) => c.id !== category.id,
    );
    this.categoriesChanged.emit(this.selectedCategories);
  }
}
