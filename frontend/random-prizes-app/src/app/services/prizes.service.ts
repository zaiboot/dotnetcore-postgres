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

  url = environment.prizeApiUrl
  constructor(private httpClient: HttpClient) { }


  MarkAvailable(p: PrizeInfo): Observable<any> {

    p.SetAvailable()
    return this.httpClient
      .put(this.url, p);

  }

  getPrizes(customerId: number): Observable<PrizeInfo[]> {
    let url = `${this.url}/customer/${customerId}`
    return this.httpClient
      .get<PrizeInfo[]>(url)
        .pipe(map((data: any) => {
          return data.map((p) => new PrizeInfo(
              p['status'], 
              p['description'], p["amount"], p["id"])
              )
        })
      );
  }
}
