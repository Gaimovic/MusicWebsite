import { Component, OnInit } from '@angular/core';
import { MusicShopService } from '../shared/services/music-shop.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(
    public musicShopService: MusicShopService
    ) {}

  public ngOnInit(): void {
    this.createDummyPortfolio();
  }

  // Create dummy portfolio
  public createDummyPortfolio() {
    this.musicShopService.setDummyDatabse();
  }
}
