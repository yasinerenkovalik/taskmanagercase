export enum TaskStatus {
  Pending = 0,
  InProgress = 1,
  Completed = 2
}

export interface Task {
  id: string;
  title: string;
  description: string;
  status: TaskStatus;
  isDeleted: boolean;
}

export interface CreateTaskRequest {
  title: string;
  description: string;
  status: TaskStatus;
  isDeleted: boolean;
}

export interface UpdateTaskRequest {
  id: string;
  title: string;
  description: string;
  status: TaskStatus;
}