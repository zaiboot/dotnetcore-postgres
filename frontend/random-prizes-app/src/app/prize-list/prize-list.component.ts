import { Component, OnInit } from '@angular/core';
import { PrizeInfo } from '../prize-info';
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
    this.prizeList = this.prizesService.getPrizes()
  }

}
