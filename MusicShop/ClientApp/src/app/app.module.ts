import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AlbumComponent } from './albums/album.component';
import { AlbumFormComponent } from './albums/album-form/album-form.component';
import { AlbumFormModule } from './albums/album-form/album-form.module';
import { AlbumModule } from './albums/album.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ConcertComponent } from './concerts/concert.component';
import { ConcertFormModule } from './concerts/concert-form/concert-form.module';
import { ConcertModule } from './concerts/concert.module';
import { MatDatepickerModule } from '@angular/material/datepicker';


// import { MatDialogModule } from '@angular/m'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    AlbumFormModule,
    AlbumModule,
    ConcertFormModule,
    ConcertModule,
    MatDatepickerModule,
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'concerts', component: ConcertComponent },
      { path: 'albums', component: AlbumComponent },
      { path: 'create-album', component: AlbumFormComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
