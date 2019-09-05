import { Component, OnInit } from '@angular/core';
import { PrizeInfo } from '../prize-info';
import { Status } from '../prize-info'
import { PrizeInfoComponent } from '../prize-info/prize-info.component'

@Component({
  selector: 'app-prize-list',
  templateUrl: './prize-list.component.html',
  styleUrls: ['./prize-list.component.css']
})
export class PrizeListComponent implements OnInit {

  protected prizeList: PrizeInfo[]
  constructor() { }

  ngOnInit() {
    this.prizeList = [
      new PrizeInfo(Status.Available, "Zeus1", 10),
      new PrizeInfo(Status.Available, "Zeus2", 20),
      new PrizeInfo(Status.Unavailable, "Zeus3", 30),
      new PrizeInfo(Status.Unavailable, "Zeus4", 30),
      new PrizeInfo(Status.Unavailable, "Zeus5", 30),
      new PrizeInfo(Status.Unavailable, "Zeus6", 30),
      new PrizeInfo(Status.Unavailable, "Zeus7", 30),
      new PrizeInfo(Status.Unavailable, "Zeus8", 30),
      new PrizeInfo(Status.Unavailable, "Zeus9", 30),
    ]

  }

}
