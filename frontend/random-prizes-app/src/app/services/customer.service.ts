import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerInformation } from '../models/customer-information';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  getCustomerInformation(id: number): Observable<CustomerInformation> {

    let url =`${environment.customerApiUrl}/${id}`
    return this.httpClient
      .get<CustomerInformation>(url)
      .pipe(map((data: any) => {
        let c = new CustomerInformation()
        c.Id = id
        c.Name = data["name"]
        c.ClaimedAmount = data["claimedAmount"]
        return c
      })
      )
  }
}
