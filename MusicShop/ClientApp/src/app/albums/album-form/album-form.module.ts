import { NgModule } from "@angular/core";
import { AlbumFormComponent } from "./album-form.component";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

@NgModule({
    declarations: [
      AlbumFormComponent
    ],
    imports: [
      CommonModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule
    ],
    exports: [AlbumFormComponent],
    providers: []
})
export class AlbumFormModule { }
  