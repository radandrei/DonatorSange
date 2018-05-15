import { Donor } from "./donor";
import {BloodType } from "./bloodType";

export class DonorData{
    id:number;
    birthdate:Date;
    bloodType:BloodType;
    donor:Donor;
    email:string;
    gender:string;
    phone:string;
    weight:number;
}