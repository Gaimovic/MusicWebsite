import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { MatDialogModule } from "@angular/material/dialog";
import { SongComponent } from "./album-song.component";

@NgModule({
    declarations: [
        SongComponent
    ],
    imports: [
      CommonModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule,
      MatDialogModule
    ],
    exports: [SongComponent],
    providers: []
})
export class SongModule { }