import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-task-delete',
  standalone: true,
  imports: [],
  templateUrl: './task-delete.component.html',
})
export class TaskDeleteComponent {
  @Input() taskId!: number;

  constructor(
    private taskService: TaskService,
    private router: Router,
  ) {}

  onDelete() {
    if (confirm('Are you sure you want to delete this task?')) {
      this.taskService.deleteTask(this.taskId).subscribe(
        () => {},
        (error) => {
          this.router.navigate(['/error'], {
            queryParams: {
              message: 'Error deleting tasks: ' + error.message,
            },
          });
        },
      );
    }
    this.router.navigate(['/task-list']);
  }
}
