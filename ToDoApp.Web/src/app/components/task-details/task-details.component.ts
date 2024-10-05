import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskModel } from '../../models/task/task.model';
import { NgClass, NgForOf, NgIf } from '@angular/common';
import { TaskDeleteComponent } from '../task-delete/task-delete.component';

@Component({
  selector: 'app-task-details',
  standalone: true,
  imports: [NgForOf, NgClass, TaskDeleteComponent, NgIf],
  templateUrl: './task-details.component.html',
})
export class TaskDetailsComponent implements OnInit {
  task: TaskModel | null = null;

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}
  ngOnInit() {
    const taskId = this.route.snapshot.params['id'];
    this.taskService.getTaskById(taskId).subscribe(
      (task: TaskModel) => {
        this.task = task;
      },
      (error) => {
        console.error('Error loading task', error);
      },
    );
  }

  onUpdate(): void {
    this.router.navigate(['/task-update', this.task?.id]);
  }

  onReturn(): void {
    this.router.navigate(['/task-list']);
  }
}
