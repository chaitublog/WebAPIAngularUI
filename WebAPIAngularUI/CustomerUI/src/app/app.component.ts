import { Component, OnInit } from '@angular/core';
import {Router,  RouterLink} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  title = 'CustomerUI';

  isLogin:boolean=false;
  constructor(private router: Router) { }
  ngOnInit() {
    alert('hi');
    if(localStorage.getItem('currentUser'))
    {
      this.isLogin=true;
    }
    else{
      this.router.navigate(['/Login']);
    }
  }
  logout()
  {
    this.isLogin=false;
    this.router.navigate(['/Login']);
  }
}
