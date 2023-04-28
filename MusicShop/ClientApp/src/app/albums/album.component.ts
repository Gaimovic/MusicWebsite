import { Component, OnInit } from '@angular/core';
import { MusicShopService } from '../shared/services/music-shop.service';
import { MatDialog } from '@angular/material/dialog';
import { SongComponent } from './album-songs/album-song.component';

@Component({
  selector: 'albums',
  templateUrl: './album.component.html',
  styleUrls: ['./album.component.scss']
})
export class AlbumComponent implements OnInit {

  public albums: any = [];
  
  constructor(
    public musicShopService: MusicShopService,
    public dialog: MatDialog
    ) {}

  public ngOnInit(): void {
    this.getAlbums();
  }

  public getAlbums() {
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

  openDialog(album: any) {
    if(album.songs[0] !== null)
        this.dialog.open(SongComponent, { data: { songs: album.songs }});
  }
}
