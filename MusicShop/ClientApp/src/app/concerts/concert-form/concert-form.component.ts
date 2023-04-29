import { Component, Inject, OnInit, Output } from '@angular/core';
import { MusicShopService } from '../../shared/services/music-shop.service'
import { AlbumForm, ConcertForm } from 'src/app/models/album.model';
import { FormControl } from '@angular/forms';
import { EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'concert-create-form',
  templateUrl: './concert-form.component.html',
  styleUrls: ['./concert-form.component.scss']
})
export class ConcertFormComponent {
  @Output() public refresh = new EventEmitter<Observable<any>>();
  public form: AlbumForm;
  public concerts$: Observable<any> | undefined;
  public formWasSubmited: boolean = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: string,
    private dialogRef: MatDialogRef<ConcertFormComponent>,
    public musicShopService: MusicShopService,
    ) {
        this.form = new ConcertForm();
    }

  get getStartDateControl() {
    return (<FormControl>this.form.get('concertStartDate'));
  }

  async createConcert() {
    this.formWasSubmited = true;
    if(this.form.valid) {
      await new Promise<void>((resolve, reject) => {
        var request = this.form.getRawValue();
        this.musicShopService.addNewConcert(request)
          .toPromise()
          .then(
            res => { 
             // Success
             this.dialogRef.close({ data: this.musicShopService.getConcerts()})
             this.formWasSubmited = false;
             resolve();
            }, (msg) => { 
             // Error
             reject(msg);
            }
          );
      });
    }
   }
  
}
