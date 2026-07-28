import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import { Project } from '../models/project.model';
import { CreateProject } from '../models/create-project.model';
import { UpdateProject } from '../models/update-project.model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private http = inject(HttpClient);

  private readonly apiUrl =
    `${environment.apiUrl}/projects`;

  getAll(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl);
  }

  getById(id: number): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}/${id}`);
  }

  create(project: CreateProject): Observable<Project> {
    return this.http.post<Project>(this.apiUrl, project);
  }

  update(id: number, project: UpdateProject): Observable<void> {
    return this.http.put<void>(
      `${this.apiUrl}/${id}`,
      project
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(
      `${this.apiUrl}/${id}`
    );
  }

}