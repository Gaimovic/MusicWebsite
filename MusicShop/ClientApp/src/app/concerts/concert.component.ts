import { Component, OnInit } from '@angular/core';
import { MusicShopService } from '../shared/services/music-shop.service';
import {MatDialog} from '@angular/material/dialog';
import { ConcertFormComponent } from './concert-form/concert-form.component';

@Component({
  selector: 'concerts',
  templateUrl: './concert.component.html',
  styleUrls: ['./concert.component.scss']
})
export class ConcertComponent implements OnInit {

  public concerts: any = [];
  
  constructor(
    public musicShopService: MusicShopService,
    public dialog: MatDialog
    ) {}

  public ngOnInit(): void {
    this.getConcerts();
  }

  public getConcerts() {
    this.musicShopService.getConcerts()
    .subscribe({
        next: response => { this.concerts = response; console.log(response)},
        error: error => console.log(error)
    });
  }

  removeConcert(concertId: any) {
    this.musicShopService.removeConcert(concertId).subscribe({ next: r => this.getConcerts()});
  }

  refreshConcerts(event: any) {
    this.getConcerts();
  }

  openDialog() {
    const dialogRef = this.dialog.open(ConcertFormComponent);

    dialogRef.afterClosed().subscribe(result => {
        this.getConcerts();
    });
  }
}
