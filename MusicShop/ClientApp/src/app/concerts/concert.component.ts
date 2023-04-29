import { Component} from '@angular/core';
import { MusicShopService } from '../shared/services/music-shop.service';
import { ConcertFormComponent } from './concert-form/concert-form.component';
import { Observable } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'concerts',
  templateUrl: './concert.component.html',
  styleUrls: ['./concert.component.scss']
})
export class ConcertComponent {

  public concerts$: Observable<any> | undefined;
  
  constructor(
    public musicShopService: MusicShopService,
    public dialog: MatDialog
    ) {
      this.getConcerts();
    }


  async removeConcert(concertId: any) {
    await this.musicShopService.removeConcert(concertId).subscribe({ next: r =>  this.getConcerts()});
  }

  async refreshConcerts(concerts: Observable<any>) {
    this.concerts$ = await concerts;
  }

  openDialog() {
    const dialogRef = this.dialog.open(ConcertFormComponent);

    dialogRef.afterClosed().subscribe((result) => {
      this.concerts$ = result.data;
    });
  }

  public async getConcerts() {
    this.concerts$ = await this.musicShopService.getConcerts();
  }
}
