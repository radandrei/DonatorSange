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
    constructor(id:number,username:string,role:Role,firstName:string, lastName:string,medicalUnit:MedicalUnit){
        this.id = id;
        this.username = username;
        this.role = role;
        this.firstName = firstName;
        this.lastName = lastName;
        this.medicalUnit = medicalUnit;
    }
}