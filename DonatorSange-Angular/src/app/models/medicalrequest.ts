import { RequestStatus } from "./requestStatus";
import { Address } from "./address";
import { BloodComponentType } from "./bloodComponentType";
import { User } from "./user";
import { MedicalUnit } from "./medicalUnit";

export class MedicalRequest{
    id:number;
    bloodComponentType:BloodComponentType;
    priority:string;
    quantity:number;
    requestStatus:RequestStatus;
    user:User;
    medicalUnit:MedicalUnit;
}