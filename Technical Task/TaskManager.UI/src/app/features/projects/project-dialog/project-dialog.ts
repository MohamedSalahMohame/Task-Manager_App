import { Component, inject, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef
} from '@angular/material/dialog';

import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { Project } from '../../../core/models/project.model';


@Component({
  selector: 'app-project-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,

    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './project-dialog.html',
  styleUrl: './project-dialog.css'
})
export class ProjectDialogComponent {


  private fb = inject(FormBuilder);


  private dialogRef =
    inject(MatDialogRef<ProjectDialogComponent>);



  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: Project | null
  ) {}



  form = this.fb.group({

    name: [
      '',
      Validators.required
    ],

    description: ['']

  });



  ngOnInit(): void {


    if (this.data) {

      this.form.patchValue({

        name: this.data.name,

        description: this.data.description

      });

    }


  }



  save() {


    if (this.form.invalid)
      return;


    this.dialogRef.close({

      ...this.form.value,

      id: this.data?.id

    });


  }



  cancel() {

    this.dialogRef.close();

  }


}