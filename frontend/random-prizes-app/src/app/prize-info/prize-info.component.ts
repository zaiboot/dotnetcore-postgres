import { Component, OnInit, Input } from '@angular/core';
import { PrizeInfo } from '../models/prize-info';


@Component({
  selector: 'app-prize-info',
  templateUrl: './prize-info.component.html',
  styleUrls: ['./prize-info.component.css'],
})


export class PrizeInfoComponent implements OnInit {
  @Input()  prizeInfo:PrizeInfo
  remainingTime: number =  60*5
  timeout:number = 1000
  constructor() { }
  
  decreaseCount(){
    this.remainingTime -=1  
    if (this.remainingTime > 0) {
      setTimeout(() => this.decreaseCount(), this.timeout);
    }
  }

  ngOnInit() {
    setTimeout(() => {
      this.decreaseCount();
    }, this.timeout);
  }

}
