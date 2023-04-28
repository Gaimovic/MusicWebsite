import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { ConcertFormComponent } from "./concert-form.component";
import { DefaultMatCalendarRangeStrategy, MAT_DATE_RANGE_SELECTION_STRATEGY, MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatNativeDateModule } from "@angular/material/core";
import { MatInputModule } from "@angular/material/input";
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
    declarations: [
      ConcertFormComponent,
    ],
    imports: [
      CommonModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule,
      MatDatepickerModule,
      MatNativeDateModule,
      MatButtonModule,
      MatFormFieldModule,
      MatInputModule,
      MatDialogModule
    ],
    exports: [ConcertFormComponent],
    providers: [
      { provide: MAT_DATE_RANGE_SELECTION_STRATEGY, useClass: DefaultMatCalendarRangeStrategy},
      MatDatepickerModule,
      MatNativeDateModule,
    ]
})
export class ConcertFormModule { }
  