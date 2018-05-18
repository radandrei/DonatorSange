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
import { BloodComponentQuantity } from '../models/bloodComponentQuantity';
import { DonorBloodDonation } from '../models/donorBloodDonation';


@Injectable()
export class DonationService {
    baseUrl: string = '';
    DonationUrl;


    constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
        this.baseUrl = configService.getApiURI();
        this.DonationUrl = this.baseUrl + "/Donation";
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

    submit(donorId: number, bloodComponents: Array<BloodComponentQuantity>, diseases: boolean): Observable<boolean> {
        debugger
        var donation = new DonorBloodDonation(donorId, bloodComponents, diseases);

        return this.http.post<boolean>(this.DonationUrl + "/submitbloodcomponents/", donation);
    }
}