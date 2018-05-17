import { Role } from "./role";
import { Donor } from "./donor";
import { Address } from "./address";
import { MedicalUnit } from "./medicalUnit";

export class User{
    id:number;
    username:string;
    role:Role;
    firstName:string;
    lastName:string;
    medicalUnit:MedicalUnit;
    constructor(id:number,username:string,role:Role,donor:Donor,address:Address){}
}