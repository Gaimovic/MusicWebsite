import { Component, OnInit, Output } from '@angular/core';
import { MusicShopService } from '../../shared/services/music-shop.service'
import { AlbumForm, ConcertForm } from 'src/app/models/album.model';
import { FormControl } from '@angular/forms';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'concert-create-form',
  templateUrl: './concert-form.component.html',
  styleUrls: ['./concert-form.component.scss']
})
export class ConcertFormComponent implements OnInit {
  @Output() public refresh = new EventEmitter<boolean>();
  public form: AlbumForm;

  constructor(
    public musicShopService: MusicShopService
    ) {
        this.form = new ConcertForm();
    }

  public ngOnInit(): void {
  }

  get getStartDateControl() {
    return (<FormControl>this.form.get('concertStartDate'));
  }

  createConcert() {
    var request = this.form.getRawValue();
    if(this.form.valid) {
        this.musicShopService.addNewConcert(request)
        .subscribe({
            next: response => this.refresh.emit(true),
            error: error => console.log(error)
        });
    }
  }
}
