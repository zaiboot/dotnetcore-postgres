import { Injectable } from '@angular/core';
import { PrizeInfo, Status } from '../models/prize-info';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PrizesService {

  constructor(private httpClient: HttpClient) { }

  getPrizes(): Observable<PrizeInfo[]> {

    let url = environment.prizeApiUrl
    return this.httpClient
      .get<PrizeInfo[]>(url)
      .pipe(map( (data: any) => {
          return data.map((p) => new PrizeInfo(Status.Unavailable, p['description'], p["amount"]) )        
      })
      );
  }
}
