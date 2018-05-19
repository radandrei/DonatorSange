import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MedicalRequest } from '../models/medicalrequest';



@Injectable()

export class RequestService {
  baseUrl: string = '';
  MedicalRequestUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    this.baseUrl = configService.getApiURI();
    this.MedicalRequestUrl = this.baseUrl + "/MedicalRequest";
  }

  extractData(result: Response): MedicalRequest[] {
    return result.json();
  }


  add(body): Observable<MedicalRequest> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<MedicalRequest>(this.MedicalRequestUrl + "/add", body, httpOptions);

  }


  loginFailed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }

  deleteMedicalRequest(id) {
    this.http.delete(this.MedicalRequestUrl + "/delete/" + id)
      .toPromise()
      .then()
      .catch(this.loginFailed);
  }

  getMedicalRequests(id: number | string): Observable<MedicalRequest[]> {
    return this.http.get<MedicalRequest[]>(this.MedicalRequestUrl + "/getbyuser/" + id);
  }

  getAllMedicalRequests(): Observable<MedicalRequest[]> {
    return this.http.get<MedicalRequest[]>(this.MedicalRequestUrl + "/getallrequests");
  }

  getRequest(id:number|string):Observable<MedicalRequest>{
    return this.http.get<MedicalRequest>(this.MedicalRequestUrl+"/getRequest");
  }

  updateRequest(request:MedicalRequest,distributionQuantity:number){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    let data={
      "request":request,
      "distributonQuantity":distributionQuantity
    }
    
    const body=JSON.stringify(data);
    return this.http.post(this.MedicalRequestUrl+"/updateRequest",body,httpOptions);
  }

  addMedicalRequest(request: MedicalRequest): Observable<boolean> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post<boolean>(this.MedicalRequestUrl + "/addMedicalRequest", request, httpOptions);
  }

  getBloodComponentTypeQuantity(bloodComponentTypeId):Observable<number>{
    return this.http.get<number>(this.MedicalRequestUrl+"/getBCTQuantity/"+bloodComponentTypeId);
  }

}
