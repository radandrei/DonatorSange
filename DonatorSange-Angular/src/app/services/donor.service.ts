import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Donor } from '../models/donor';
import { DonorData } from '../models/donorData';



@Injectable()

export class DonorService {

  baseUrl: string = '';
  DonorUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    this.baseUrl = configService.getApiURI();
    this.DonorUrl = this.baseUrl + "/Donation";
  }

  extractData(result: Response): Donor[] {
    return result.json();
  }

  add(body): Observable<Donor> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<Donor>(this.DonorUrl + "/add", body, httpOptions);

  }

  loginFailed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }

  deleteDonor(id) {
    this.http.delete(this.DonorUrl + "/delete/" + id)
      .toPromise()
      .then()
      .catch(this.loginFailed);
  }

  getDonors(medicalUnitId): Observable<Donor[]> {
    return this.http.get<Donor[]>(this.DonorUrl + "/getdonors/"+medicalUnitId);
  }

  getDonor(donorId):Observable<Donor>{
    return this.http.get<Donor>(this.DonorUrl+"/getdonor/"+donorId);
  }


  updateDonorData(donorData:DonorData){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    
    const body=JSON.stringify(donorData);
    return this.http.post(this.DonorUrl+"/updateDonorData",body,httpOptions);

  }
}