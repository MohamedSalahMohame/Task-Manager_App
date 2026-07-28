import { Routes } from '@angular/router';

import { LayoutComponent } from './layout/layout';
import { ProjectListComponent } from './features/projects/project-list/project-list';
import { TaskListComponent } from './features/tasks/task-list/task-list';

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        component: ProjectListComponent
      },
      {
        path: 'projects/:projectId/tasks',
        component: TaskListComponent
      }
    ]
  }
];