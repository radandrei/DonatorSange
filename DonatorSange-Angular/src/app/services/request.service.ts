import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Injectable()

export class RequestService {
  baseUrl: string = '';
  RequestUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    this.baseUrl = configService.getApiURI();
    this.RequestUrl = this.baseUrl + "/Request";
  }

  extractData(result: Response): Request[] {
    return result.json();
  }


  add(body): Observable<Request> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<Request>(this.RequestUrl + "/add", body, httpOptions);

  }


  loginFailed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }

  deleteRequest(id) {
    this.http.delete(this.RequestUrl + "/delete/" + id)
      .toPromise()
      .then()
      .catch(this.loginFailed);
  }

  getRequests(id: number | string): Observable<Request[]> {
    return this.http.get<Request[]>(this.RequestUrl + "/getbyuser/" + id);
  }

  getAllRequests(id: number | string): Observable<Request[]> {
    return this.http.get<Request[]>(this.RequestUrl + "/getallbyuser/" + id);
  }

  addRequest(request: Request): Observable<boolean> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post<boolean>(this.RequestUrl + "/addRequest", request, httpOptions);
  }

}
