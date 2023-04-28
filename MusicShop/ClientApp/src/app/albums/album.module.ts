import { NgModule } from "@angular/core";
import { AlbumComponent } from "./album.component";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AlbumFormModule } from "./album-form/album-form.module";
import { CommonModule } from "@angular/common";

@NgModule({
    declarations: [
        AlbumComponent
    ],
    imports: [
      CommonModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule,
      AlbumFormModule
    ],
    exports: [AlbumComponent],
    providers: []
})
export class AlbumModule { }