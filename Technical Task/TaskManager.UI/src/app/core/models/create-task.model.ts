export interface CreateTask {
  title: string;
  description?: string;
  dueDate?: Date;
  status: number;
  projectId: number;
}