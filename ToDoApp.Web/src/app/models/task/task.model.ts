import { CategoryModel } from '../category/category.model';
import { UserModel } from '../user/user.model';

export interface TaskModel {
  id: number;
  userId: string;
  user: UserModel;
  name: string;
  description?: string;
  dueDate: Date;
  isDone: boolean;
  categories?: CategoryModel[];
}
