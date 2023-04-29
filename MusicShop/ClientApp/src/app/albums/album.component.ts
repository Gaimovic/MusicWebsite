import { Component, OnInit } from '@angular/core';
import { MusicShopService } from '../shared/services/music-shop.service';
import { MatDialog } from '@angular/material/dialog';
import { SongComponent } from './album-songs/album-song.component';
import { Observable } from 'rxjs';
import { AlbumFormComponent } from './album-form/album-form.component';

@Component({
  selector: 'albums',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent implements OnInit {

  public albums$: Observable<any> | undefined;
  public albums: any = [];
  
  constructor(
    public musicShopService: MusicShopService,
    public dialog: MatDialog
    ) {}

  public ngOnInit(): void {
    this.getAlbums();
  }

  public getAlbums() {
    this.albums$ = this.musicShopService.getAlbums();
    this.musicShopService.getAlbums()
    .subscribe({
        next: response => this.albums = response,
        error: error => console.log(error)
    });
  }

  removeAlbum(albumId: any) {
    this.musicShopService.removeAlbum(albumId).subscribe({ next: r => this.getAlbums()});
  }

  refreshAlbum(event: any) {
    this.getAlbums();
  }

  openCreateForm() {
    var dialogRef = this.dialog.open(AlbumFormComponent);

    dialogRef.afterClosed().subscribe((result) => {
      this.getAlbums();
    });
  }

  openDialog(album: any) {
    if(album.songs[0] !== null)
        this.dialog.open(SongComponent, { data: { songs: album.songs }});
  }
}
