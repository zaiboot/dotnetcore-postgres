import { Component, OnInit } from '@angular/core';
import { PrizeInfo } from '../prize-info';


@Component({
  selector: 'app-prize-info',
  templateUrl: './prize-info.component.html',
  styleUrls: ['./prize-info.component.css']
})


export class PrizeInfoComponent implements OnInit {

  constructor(private prizeInfo:PrizeInfo) { }

  ngOnInit() {
  }

}
