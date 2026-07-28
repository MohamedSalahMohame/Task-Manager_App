import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectService } from '../../../core/services/project.service';
import { Project } from '../../../core/models/project.model';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { ProjectDialogComponent } from '../project-dialog/project-dialog';

import { Router } from '@angular/router';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatDialogModule
  ],
  templateUrl: './project-list.html',
  styleUrl: './project-list.css'
})
export class ProjectListComponent implements OnInit {

  private projectService = inject(ProjectService);
  private dialog = inject(MatDialog);
  private router = inject(Router);
  private cdr = inject(ChangeDetectorRef);

  projects: Project[] = [];

  ngOnInit(): void {
    this.loadProjects();
  }

  loadProjects(): void {

    this.projectService.getAll().subscribe({

      next: (response) => {

        console.log("Response:", response);

        // إنشاء Array جديدة
        this.projects = [...response];

        console.log("Projects after assignment:", this.projects);

        // إجبار Angular على إعادة تحديث الواجهة
        this.cdr.detectChanges();

      },

      error: (err) => {
        console.error(err);
      }

    });

  }

  openCreateDialog(): void {

    const dialogRef = this.dialog.open(ProjectDialogComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe(result => {

      if (!result)
        return;

      this.projectService.create(result).subscribe({

        next: (response) => {

          console.log("Project Created:", response);

          this.loadProjects();

        },

        error: (err) => {

          console.error("Create Error:", err);

        }

      });

    });

  }

  deleteProject(id: number): void {

    const confirmDelete = confirm(
      'Are you sure you want to delete this project?'
    );

    if (!confirmDelete)
      return;

    this.projectService.delete(id).subscribe({

      next: () => {

        console.log("Project Deleted");

        this.loadProjects();

      },

      error: (err) => {

        console.error("Delete Error:", err);

      }

    });

  }

  openEditDialog(project: Project): void {

    const dialogRef = this.dialog.open(ProjectDialogComponent, {

      width: '500px',

      data: project

    });

    dialogRef.afterClosed().subscribe(result => {

      if (!result)
        return;

      this.projectService.update(
        project.id,
        {
          name: result.name,
          description: result.description
        }
      ).subscribe({

        next: () => {

          console.log("Project Updated");

          this.loadProjects();

        },

        error: (err) => {

          console.error("Update Error:", err);

        }

      });

    });

  }

  viewTasks(projectId: number): void {

    this.router.navigate([
      '/projects',
      projectId,
      'tasks'
    ]);

  }
}