import { BloodComponentType } from "./bloodComponentType";
import { RequestStatus } from "./requestStatus";
import { Address } from "./address";

export class Request{
    id:number;
    address:Address;
    bloodComponentType:BloodComponentType;
    priority:string;
    quantity:number;
    requestStatus:RequestStatus;
}