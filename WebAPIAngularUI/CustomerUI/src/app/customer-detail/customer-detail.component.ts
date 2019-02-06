import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { CustomerServiceService } from '../customer-service.service';
import {customer} from '../customer';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  custForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  currCust:customer;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: CustomerServiceService,
    ) { }

  ngOnInit() {
    this.custForm = this.formBuilder.group({
      custFirstName: ['', Validators.required],
      custLastName:[''],
      custAddress: ['', Validators.required],
      custContactNum:['',Validators.required],
      custCountry:['',Validators.required]
    });
    this.currCust=new customer();
  }
  //to access form controles
  get f() { return this.custForm.controls; }

  onSubmit()
  {
    this.submitted = true;

    // stop here if form is invalid
    if (this.custForm.invalid) {
        return;
    }

    this.currCust.custFirstName=this.f.custFirstName.value;
    this.currCust.custLastName=this.f.custLastName.value;
    this.currCust.custAddress=this.f.custAddress.value;
    this.currCust.custContactNum=this.f.custContactNum.value;
    this.currCust.custCountry=this.f.custCountry.value;

    this.api.createCustomer(this.currCust).subscribe(
      res => {        
        alert(res);
      }
    );

  }

}
