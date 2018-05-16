import { Address } from "./address"
import { DonorData } from "./donorData";
import { User } from "./user";
import { DonationRequest } from "./donationRequest";

export class Donor{
    id:number;
    address:Address;
    birthdate:Date;
    phone:string;
    email:string;
    gender:string;
    donorData:DonorData;
    donationRequest:DonationRequest;
    user:User;
}