import { Address } from "./address"
import { DonorData } from "./donorData";
import { User } from "./user";
import { DonationRequest } from "./donationRequest";
import { Gender } from "./gender";

export class Donor{
    id:number;
    address:Address;
    birthdate:Date;
    phone:string;
    email:string;
    gender:Gender;
    donorData:DonorData;
    donationRequest:DonationRequest;
    user:User;
    static initialize(){
        let donor = new Donor();
        donor.id = 0;
        donor.address = Address.initialize();
        donor.birthdate = new Date(1990, 10, 10);
        donor.donationRequest = DonationRequest.initialize();
        donor.donorData = null;
        donor.email = null;
        donor.gender = Gender.initialize();
        donor.phone = null;
        donor.user = new User(0, null, null, null, null, null);
        return donor;

    }
}