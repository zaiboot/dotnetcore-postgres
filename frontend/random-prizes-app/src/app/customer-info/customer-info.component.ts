import { Component, OnInit, Input } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { CustomerInformation } from '../models/customer-information';

@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrls: ['./customer-info.component.css']
})
export class CustomerInfoComponent implements OnInit {

  @Input() public customerId:number
  private customerInfo:CustomerInformation = new CustomerInformation

  constructor(private service: CustomerService) { }

  ngOnInit() {
    this.service.getCustomerInformation(this.customerId).subscribe(d => { this.customerInfo = d})
  }

}
