import { Component, OnInit, Input } from '@angular/core';
import { PrizeInfo } from '../models/prize-info';


@Component({
  selector: 'app-prize-info',
  templateUrl: './prize-info.component.html',
  styleUrls: ['./prize-info.component.css'],
  //providers: [PrizeInfo]
})


export class PrizeInfoComponent implements OnInit {
  @Input()  prizeInfo:PrizeInfo
  constructor() { }

  ngOnInit() {
  }

}
