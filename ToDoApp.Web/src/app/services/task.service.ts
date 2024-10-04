import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { API_URLS } from '../shared/constants';
import { PagedTasksResponse } from '../models/task/paged-tasks-response.model';
import { PagedTasksRequestModel } from '../models/task/paged-tasks-request.model';

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
    return this.http.get<PagedTasksResponse>(API_URLS.TASK.GET_ALL, {
      params,
    });
  }
}
