import { Component, OnInit } from '@angular/core';
import { PrizeInfo } from '../prize-info';
import {Status} from '../prize-info'
@Component({
  selector: 'app-prize-list',
  templateUrl: './prize-list.component.html',
  styleUrls: ['./prize-list.component.css']
})
export class PrizeListComponent implements OnInit {

  protected prizeList:PrizeInfo[]
  constructor() { }

  ngOnInit() {
    this.prizeList =  [ 
      new PrizeInfo(Status.Unavailable,"Zeus1",10 ),
      new PrizeInfo(Status.Unavailable,"Zeus2",20 ),
      new PrizeInfo(Status.Unavailable,"Zeus3",30 )
    ]
    
  }

}
