import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';

import { first } from 'rxjs/operators';
import { UserLoginServiceService } from '../user-login-service.service';
import {userLogin} from '../user-login';
import {AlertService} from '../alert.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  user: userLogin;
  
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private api: UserLoginServiceService,
    private alertService: AlertService
    
  ) { 
    
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
    this.user=new userLogin();
    // reset login status
    this.api.logout();
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }
  //to access form controles
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
        return;
    }

    this.loading = true;
    
    this.user.username=this.f.username.value;
    this.user.password=this.f.password.value;

    this.api.authenticateUser(this.user)
        .pipe(first())
        .subscribe(
            data => {
              //  this.router.navigate([this.returnUrl]);
              this.router.navigate(['/CustList']);
            },
            error => {   
              this.alertService.error(error);            
                this.loading = false;
            });
            
}
}
