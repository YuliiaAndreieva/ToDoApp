import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgForOf, NgIf } from '@angular/common';
import { ButtonComponent } from '../../shared/buttons/button/button.component';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [NgForOf, ButtonComponent, NgIf],
  templateUrl: './pagination.component.html',
})
export class PaginationComponent {
  @Input() totalCount: number = 1;
  @Input() currentPage: number = 1;
  @Input() pageSize: number = 1;
  @Input() hasPreviousPage: boolean = false;
  @Input() hasNextPage: boolean = false;
  @Output() pageChange: EventEmitter<number> = new EventEmitter();

  get totalPages(): number {
    return Math.ceil(this.totalCount / this.pageSize);
  }

  getPageNumbers(): number[] {
    const totalVisiblePages = 5;
    const pages: number[] = [];
    let startPage = Math.max(
      1,
      this.currentPage - Math.floor(totalVisiblePages / 2),
    );
    let endPage = Math.min(
      this.totalPages,
      this.currentPage + Math.floor(totalVisiblePages / 2),
    );

    if (this.currentPage <= 3) {
      endPage = Math.min(this.totalPages, totalVisiblePages);
    }

    if (this.currentPage > this.totalPages - 3) {
      startPage = Math.max(1, this.totalPages - totalVisiblePages + 1);
    }

    for (let i = startPage; i <= endPage; i++) {
      pages.push(i);
    }

    return pages;
  }

  goToPage(page: number): void {
    if (page !== this.currentPage) {
      this.pageChange.emit(page);
    }
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.pageChange.emit(this.currentPage - 1); // Emit previous page event
    }
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.pageChange.emit(this.currentPage + 1); // Emit next page event
    }
  }
}
