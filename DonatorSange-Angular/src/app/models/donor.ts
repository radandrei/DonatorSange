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
}