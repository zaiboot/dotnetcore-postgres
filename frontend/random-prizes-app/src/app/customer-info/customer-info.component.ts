import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrls: ['./customer-info.component.css']
})
export class CustomerInfoComponent implements OnInit {

  customerName = "Demo"
  claimedAmount = 0.0   
  constructor() { 
    

  }

  ngOnInit() {
  }

}
