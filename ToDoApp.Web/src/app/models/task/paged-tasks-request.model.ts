export interface PagedTasksRequestModel {
  CategoryIds?: number[];
  SearchTerm?: string;
  Page?: number;
  PageSize?: number;
}
