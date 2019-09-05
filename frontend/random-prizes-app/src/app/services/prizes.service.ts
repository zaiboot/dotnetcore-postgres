import { Injectable } from '@angular/core';
import { PrizeInfo, Status } from '../prize-info';

@Injectable({
  providedIn: 'root'
})
export class PrizesService {
  
  constructor() { }
  
  getPrizes(): PrizeInfo[]{
    return [  new PrizeInfo(Status.Available, "Zeus1", 10),
    new PrizeInfo(Status.Available, "Zeus2", 20),
    new PrizeInfo(Status.Unavailable, "Zeus3", 30),
    new PrizeInfo(Status.Unavailable, "Zeus4", 30),
    new PrizeInfo(Status.Unavailable, "Zeus5", 30),
    new PrizeInfo(Status.Unavailable, "Zeus6", 30),
    new PrizeInfo(Status.Unavailable, "Zeus7", 30),
    new PrizeInfo(Status.Unavailable, "Zeus8", 30),
    new PrizeInfo(Status.Unavailable, "Zeus9", 30)
  ]
  }
}
