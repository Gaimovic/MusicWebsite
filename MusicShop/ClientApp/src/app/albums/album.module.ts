import { NgModule } from "@angular/core";
import { AlbumComponent } from "./album.component";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AlbumFormModule } from "./album-form/album-form.module";
import { CommonModule } from "@angular/common";
import { MatDialogModule } from "@angular/material/dialog";
import { SongModule } from "./album-songs/album-song.module";

@NgModule({
    declarations: [
        AlbumComponent
    ],
    imports: [
      CommonModule,
      HttpClientModule,
      ReactiveFormsModule,
      FormsModule,
      AlbumFormModule,
      MatDialogModule,
      SongModule
    ],
    exports: [AlbumComponent],
    providers: []
})
export class AlbumModule { }