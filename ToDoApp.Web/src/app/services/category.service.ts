import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoryModel } from '../models/category/category.model';
import { API_URLS } from '../shared/api-endpoints';
import { CategoryAddModel } from '../models/category/category-add.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private http: HttpClient) {}

  getCategories(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>(API_URLS.CATEGORY.BASE_URL);
  }

  createCategory(category: CategoryAddModel) {
    return this.http.post<CategoryModel>(API_URLS.CATEGORY.BASE_URL, category);
  }
}
