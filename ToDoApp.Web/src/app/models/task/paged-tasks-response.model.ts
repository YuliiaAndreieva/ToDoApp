import { TaskModel } from './task.model';

export interface PagedTasksResponse {
  items: TaskModel[];
  page: number;
  pageSize: number;
  totalCount: number;
  hasNextPage: boolean;
  hasPreviousPage: boolean;
}
