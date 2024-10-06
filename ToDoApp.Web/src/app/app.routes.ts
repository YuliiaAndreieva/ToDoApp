import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { TaskListComponent } from './components/task-list/task-list.component';
import { AuthGuard } from './guards/auth.guard';
import { RegisterComponent } from './components/register/register.component';
import { AddEditTaskComponent } from './components/add-edit-task/add-edit-task.component';
import { TaskDetailsComponent } from './components/task-details/task-details.component';
import { ErrorPageComponent } from './components/error-page/error-page.component';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
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
  {
    path: 'task-add',
    component: AddEditTaskComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'task-update/:id',
    component: AddEditTaskComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'task-details/:id',
    component: TaskDetailsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'error',
    component: ErrorPageComponent,
  },
];
