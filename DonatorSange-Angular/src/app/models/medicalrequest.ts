import { RequestStatus } from "./requestStatus";
import { Address } from "./address";
import { BloodComponentType } from "./bloodComponentType";
import { User } from "./user";

export class MedicalRequest{
    id:number;
    address:Address;
    bloodComponentType:BloodComponentType;
    priority:string;
    quantity:number;
    requestStatus:RequestStatus;
    user:User;
}