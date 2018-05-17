import { UnitStatus } from "./unitStatus";

export class DonationRequest{
    id:number;
    RecipientName:string;
    date:Date;
    active:boolean;
    status:UnitStatus;
}