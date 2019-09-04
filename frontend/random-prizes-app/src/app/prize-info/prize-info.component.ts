import { Component, OnInit } from '@angular/core';

enum Status {
  Missed,
  Available,
  Unavailable,
  Unknown
}

@Component({
  selector: 'app-prize-info',
  templateUrl: './prize-info.component.html',
  styleUrls: ['./prize-info.component.css']
})


export class PrizeInfoComponent implements OnInit {
 
  status = Status.Unavailable
  available = false
  description = ""
  private time = 60*5;
  price = 10;

  constructor() { }

  ngOnInit() {
  }

}
