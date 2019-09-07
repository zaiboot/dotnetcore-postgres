import { Component, OnInit } from '@angular/core';
import { PrizeInfo } from '../models/prize-info';
import { PrizesService } from '../services/prizes.service';

@Component({
  selector: 'app-prize-list',
  templateUrl: './prize-list.component.html',
  styleUrls: ['./prize-list.component.css']
})
export class PrizeListComponent implements OnInit {

  protected prizeList: PrizeInfo[]
  constructor(private prizesService:PrizesService) { }

  ngOnInit() {
    this.prizesService.getPrizes().subscribe( p=> {
      this.prizeList = p
      this.prizesService.MarkAvailable(this.prizeList[0]).subscribe( p=> {
        this.prizeList[0].SetAvailable()
      })

      
    })
  }

}
