import { UnitStatus } from "./unitStatus";
import { getLocaleDateTimeFormat } from "@angular/common";

export class DonationRequest{
    id:number;
    recipientName:string;
    date:Date;
    active:boolean;
    status:UnitStatus;
    static initialize(){
        let donationRequest = new DonationRequest();
        donationRequest.id = 0;
        donationRequest.recipientName = null;
        donationRequest.date = new Date();
        donationRequest.active = false;
        donationRequest.status = UnitStatus.initialize();
        return donationRequest;
    }
}