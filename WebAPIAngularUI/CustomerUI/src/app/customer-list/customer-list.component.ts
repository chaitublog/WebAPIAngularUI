import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { customer } from '../customer';
import { CustomerServiceService } from '../customer-service.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})

export class CustomerListComponent implements OnInit {
  custList:customer[];
  
  selectedCustomer:customer;
  showSpinner=true;

  constructor(private router: Router,private api:CustomerServiceService) { }

  ngOnInit() {

    this.api.getAllCustomers().subscribe(cuss => {        
      this.custList=cuss;
      this.showSpinner=false;
      });
  }

  onSelect(selCust:customer)
  {
        
  }

}
