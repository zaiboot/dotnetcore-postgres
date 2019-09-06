import { Injectable } from '@angular/core';
import { CustomerInformation } from '../models/customer-information';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor() { }

  getCustomerInformation(id:number): CustomerInformation{
    return new CustomerInformation(id, "Test", 0)

  }
}
