import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import {
  MatDialogModule,
  MatDialogRef,
  MAT_DIALOG_DATA
} from '@angular/material/dialog';

import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
  selector: 'app-task-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,

    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './task-dialog.html',
  styleUrl: './task-dialog.css'
})
export class TaskDialogComponent {

  private fb = inject(FormBuilder);

  private dialogRef =
    inject(MatDialogRef<TaskDialogComponent>);

  private data =
    inject(MAT_DIALOG_DATA, { optional: true });

  form = this.fb.group({

    title: ['', Validators.required],

    description: [''],

    dueDate: [null],

    status: [0, Validators.required]

  });

  constructor() {

    if (this.data) {

      this.form.patchValue({

        title: this.data.title,

        description: this.data.description,

        dueDate: this.data.dueDate,

        status: this.data.status

      });

    }

  }

  save(): void {

    if (this.form.invalid)
      return;

    this.dialogRef.close(this.form.value);

  }

  cancel(): void {

    this.dialogRef.close();

  }

}