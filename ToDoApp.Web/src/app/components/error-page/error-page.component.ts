import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  standalone: true,
})
export class ErrorPageComponent implements OnInit {
  errorMessage: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.errorMessage = params['message'] || 'An unknown error occurred.';
    });
  }

  goBack() {
    this.router.navigate(['/task-list']);
  }
}
