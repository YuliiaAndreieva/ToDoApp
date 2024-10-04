import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { TaskListComponent } from './components/task-list/task-list.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: '/task-list',
    pathMatch: 'full',
  },
  {
    path: 'task-list',
    component: TaskListComponent,
    canActivate: [AuthGuard],
  },
];
