import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CustomerListComponent } from '../app/customer-list/customer-list.component';
import { CustomerDetailComponent } from '../app/customer-detail/customer-detail.component';
import { LoginComponent } from '../app/login/login.component'

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'CustList', component: CustomerListComponent },
  { path: 'CustDetails', component: CustomerDetailComponent },
  { path: 'Login', component: LoginComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ],  
  declarations: []
})
export class AppRoutingModule { }


