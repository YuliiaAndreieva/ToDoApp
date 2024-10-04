import { CategoryModel } from '../category/category.model';

export interface TaskModel {
  id: number;
  userId: string;
  name: string;
  description?: string;
  dueDate: Date;
  isDone: boolean;
  categoryDtos?: CategoryModel[];
}
