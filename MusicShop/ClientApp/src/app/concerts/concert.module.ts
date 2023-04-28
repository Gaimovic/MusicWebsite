import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { ConcertComponent } from "./concert.component";
import { ConcertFormModule } from "./concert-form/concert-form.module";
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
    declarations: [
        ConcertComponent
    ],
    imports: [
      CommonModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule,
      ConcertFormModule,
      MatDialogModule
    ],
    exports: [ConcertComponent],
    providers: []
})
export class ConcertModule { }