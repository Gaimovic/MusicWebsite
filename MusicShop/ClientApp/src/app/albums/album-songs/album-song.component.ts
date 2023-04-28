import { Component, Inject, OnInit } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';

@Component({
  selector: 'songs',
  templateUrl: './album-song.component.html',
  styleUrls: ['./album-song.component.scss']
})
export class SongComponent implements OnInit {

  //public songs: any = [];
  
  constructor(@Inject(MAT_DIALOG_DATA) public data: {songs: any}) {}
  
    ngOnInit(): void {
      
    }

}
