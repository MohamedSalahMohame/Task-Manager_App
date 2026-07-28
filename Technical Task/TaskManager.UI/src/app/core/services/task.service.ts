import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import { TaskItem } from '../models/task.model';
import { CreateTask } from '../models/create-task.model';
import { UpdateTask } from '../models/update-task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private http = inject(HttpClient);

  private readonly apiUrl =
    `${environment.apiUrl}/tasks`;

  getAll(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl);
  }

  getById(id: number): Observable<TaskItem> {
    return this.http.get<TaskItem>(
      `${this.apiUrl}/${id}`
    );
  }

  getByProject(projectId: number): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(
      `${this.apiUrl}/project/${projectId}`
    );
  }


  create(task: CreateTask): Observable<TaskItem> {
    return this.http.post<TaskItem>(
      this.apiUrl,
      task
    );
  }

  update(id: number, task: UpdateTask): Observable<void> {
    return this.http.put<void>(
      `${this.apiUrl}/${id}`,
      task
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(
      `${this.apiUrl}/${id}`
    );
  }


  getByStatus(status: number): Observable<TaskItem[]> {

  return this.http.get<TaskItem[]>(
    `${this.apiUrl}/status/${status}`
  );

}
}