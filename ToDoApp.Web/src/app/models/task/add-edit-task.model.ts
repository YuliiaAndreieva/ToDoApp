export interface AddEditTaskModel {
  name: string;
  dueDate: Date;
  isDone: boolean;
  description?: string;
  categoryIds?: number[];
}
