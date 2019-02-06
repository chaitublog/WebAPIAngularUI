import { Injectable } from '@angular/core';
import { Observable, empty } from 'rxjs';
import { HttpClient,HttpErrorResponse, HttpParams  } from '@angular/common/http';
import { map, catchError, tap } from 'rxjs/operators';
import { userLogin } from '../app/user-login';
import {  Headers,  RequestOptions, ResponseContentType, Response, RequestMethod, URLSearchParams } from '@angular/http';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserLoginServiceService {
  baseUrl:string="http://localhost:5327/api/Admin/";
  

  constructor(protected http: HttpClient) { }
    private handleError(operation: String) {
      return (err: any) => {
          let errMsg = 'error in ${operation}() ';
          console.log('${errMsg}:', err)
          if(err instanceof HttpErrorResponse) {
              // you could extract more info about the error if you want, e.g.:
              console.log(`status: ${err.status}, ${err.statusText}`);
              alert('status: ${err.status}, ${err.error.Message}');
              // errMsg = ...
          }
          return Observable.throw(errMsg);
      }

  }
  
  authenticateUser(userLogin:userLogin):Observable<userLogin>
  {
    let headers: HttpHeaders = new HttpHeaders();
    headers = headers.append('Content-type', 'application/json');    
    
    return this.http.post<userLogin>(this.baseUrl+'authenticate',userLogin,{headers:headers}).pipe(
      map(user=> {
        if(user && user.token )
        {
          localStorage.setItem('currentUser', JSON.stringify(user));
          
        }
        return user;
      }));
    
  }
  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
}

}
