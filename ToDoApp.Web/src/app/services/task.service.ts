import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_URLS } from '../shared/api-endpoints';
import { PagedTasksResponse } from '../models/task/paged-tasks-response.model';
import { PagedTasksRequestModel } from '../models/task/paged-tasks-request.model';
import { TaskModel } from '../models/task/task.model';
import { AddEditTaskModel } from '../models/task/add-edit-task.model';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor(private http: HttpClient) {}

  getPagedTasks(
    request: PagedTasksRequestModel,
  ): Observable<PagedTasksResponse> {
    let params = new HttpParams();

    if (request.CategoryIds) {
      request.CategoryIds.forEach((id) => {
        params = params.append('CategoryIds', id.toString());
      });
    }
    if (request.SearchTerm) {
      params = params.append('SearchTerm', request.SearchTerm);
    }
    params = params.append('Page', request.Page?.toString() || '1');
    params = params.append('PageSize', request.PageSize?.toString() || '4');
    return this.http.get<PagedTasksResponse>(API_URLS.TASK.BASE_URL, {
      params,
    });
  }

  getTaskById(id: number): Observable<TaskModel> {
    return this.http.get<TaskModel>(API_URLS.TASK.GET_BY_ID(id));
  }

  updateTask(taskId: number, taskData: AddEditTaskModel): Observable<void> {
    return this.http.put<void>(API_URLS.TASK.GET_BY_ID(taskId), taskData);
  }

  createTask(taskData: AddEditTaskModel): Observable<TaskModel> {
    console.log(taskData);
    return this.http.post<TaskModel>(API_URLS.TASK.BASE_URL, taskData);
  }

  deleteTask(id: number): Observable<void> {
    console.log(id);
    return this.http.delete<void>(API_URLS.TASK.GET_BY_ID(id));
  }
}
