import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

import { TaskService } from '../../../core/services/task.service';
import { ProjectService } from '../../../core/services/project.service';

import { TaskItem } from '../../../core/models/task.model';
import { Project } from '../../../core/models/project.model';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { TaskDialogComponent } from '../task-dialog/task-dialog';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-list',
  standalone: true,
 imports: [
  CommonModule,
  FormsModule,
  MatDialogModule,
  MatButtonModule,
  MatIconModule
],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css'
})
export class TaskListComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private taskService = inject(TaskService);
  private projectService = inject(ProjectService);
  private dialog = inject(MatDialog);
  private cdr = inject(ChangeDetectorRef);

  projectId!: number;
  project?: Project;
  tasks: TaskItem[] = [];
selectedStatus = -1;
  ngOnInit(): void {

    this.projectId = Number(
      this.route.snapshot.paramMap.get('projectId')
    );

    console.log('Project Id:', this.projectId);

    this.loadProject();
    this.loadTasks();

  }

  loadProject(): void {

    this.projectService.getById(this.projectId).subscribe({

      next: (response) => {

        console.log('Project loaded:', response);

        this.project = response;

        this.cdr.detectChanges();

      },

      error: (err) => {

        console.error('Project Error:', err);

      }

    });

  }

  loadTasks(): void {

    this.taskService.getByProject(this.projectId).subscribe({

      next: (response) => {

        console.log('Tasks:', response);

        this.tasks = [...response];

        this.cdr.detectChanges();

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

  openCreateDialog(): void {

    const dialogRef = this.dialog.open(TaskDialogComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe(result => {

      if (!result) return;

      this.taskService.create({

        title: result.title,
        description: result.description,
        dueDate: result.dueDate,
        status: result.status,
        projectId: this.projectId

      }).subscribe({

        next: () => {

          console.log('Task Created');

          this.loadTasks();

        },

        error: (err) => {

          console.error('Create Error:', err);

        }

      });

    });

  }

  openEditDialog(task: TaskItem): void {

    const dialogRef = this.dialog.open(TaskDialogComponent, {

      width: '500px',
      data: task

    });

    dialogRef.afterClosed().subscribe(result => {

      if (!result) return;

      this.taskService.update(task.id, {

        title: result.title,
        description: result.description,
        dueDate: result.dueDate,
        status: result.status

      }).subscribe({

        next: () => {

          console.log('Task Updated');

          this.loadTasks();

        },

        error: (err) => {

          console.error('Update Error:', err);

        }

      });

    });

  }

  deleteTask(id: number): void {

    const confirmDelete = confirm(
      'Are you sure you want to delete this task?'
    );

    if (!confirmDelete) return;

    this.taskService.delete(id).subscribe({

      next: () => {

        console.log('Task Deleted');

        this.loadTasks();

      },

      error: (err) => {

        console.error('Delete Error:', err);

      }

    });

  }

  goBack(): void {

    this.router.navigate(['/']);

  }

  getStatusText(status: number): string {

    switch (status) {

      case 0: return 'To Do';
      case 1: return 'In Progress';
      case 2: return 'Done';
      default: return 'Unknown';

    }

  }

filterByStatus(): void {

  const status = Number(this.selectedStatus);

  if (status === -1) {
    this.loadTasks();
    return;
  }

  this.taskService.getByStatus(status).subscribe({

    next: (response) => {

      this.tasks = response;

    },

    error: (err) => console.error(err)

  });

}
}