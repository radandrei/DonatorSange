import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Donor } from '../models/donor';
import { DonorData } from '../models/donorData';
import { BloodType } from '../models/bloodType';
import { BloodComponentType } from '../models/bloodComponentType'
import { BloodComponent } from '../models/bloodComponent';


@Injectable()

export class DonationService {

    baseUrl: string = '';
    DonationUrl;


    constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
        this.baseUrl = configService.getApiURI();
        this.DonationUrl = this.baseUrl + "/Donation";
    }

    add(body): Observable<Donor> {

        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        return this.http.post<Donor>(this.DonationUrl + "/add", body, httpOptions);

    }

    getBloodComponents(): Observable<BloodComponent[]> {
        return this.http.get<BloodComponent[]>(this.DonationUrl + "/getbloodcomponents");
    }

    getBloodTypes(): Observable<BloodType[]> {
        return this.http.get<BloodType[]>(this.DonationUrl + "/getbloodtypes");
    }

    getDonor(donorId): Observable<Donor> {
        return this.http.get<Donor>(this.DonationUrl + "/getbyid/" + donorId);
    }


    updateDonorData(donorData: DonorData) {
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        const body = JSON.stringify(donorData);
        return this.http.post(this.DonationUrl + "/updateDonorData", body, httpOptions);

    }
}