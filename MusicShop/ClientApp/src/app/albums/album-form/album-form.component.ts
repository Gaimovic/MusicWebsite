import { Component, OnInit, Output } from '@angular/core';
import { MusicShopService } from '../../shared/services/music-shop.service'
import { AlbumForm } from 'src/app/models/album.model';
import { FormArray, FormControl, Validators } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { getGenres } from '../album.component.mock';

@Component({
  selector: 'album-create-form',
  templateUrl: './album-form.component.html',
  styleUrls: ['./album-form.component.scss']
})
export class AlbumFormComponent implements OnInit {
  @Output() public refresh = new EventEmitter<boolean>();
  public form: AlbumForm;
  public genres: any[];

  constructor(
    public musicShopService: MusicShopService
    ) {
        this.form = new AlbumForm();
        this.genres = getGenres()
    }

  public ngOnInit(): void {
  }

  get getSongControls() {
    return (<FormArray>this.form.get('songs')).controls;
  }

  addSong() {
    var controls = <FormArray> this.form.get('songs');
    controls.push(new FormControl(null, { validators: Validators.required, updateOn: 'blur'}));
    controls.updateValueAndValidity();
  }

  removeSong(index: any) {
    (<FormArray> this.form.get('songs')).removeAt(index);
  }

  createAlbum() {
    var request = this.form.getRawValue();
    if(this.form.valid) {
        this.musicShopService.addNewAlbum(request)
        .subscribe({
            next: response => this.refresh.emit(true),
            error: error => console.log(error)
        });
    }
  }
}
