import { Role } from "./role";
import { Donor } from "./donor";
import { Address } from "./address";

export class User{
    id:number;
    username:string;
    role:Role;
    donor:Donor;
    address:Address;
    firstName:string;
    lastName:string;
    constructor(id:number,username:string,role:Role,donor:Donor,address:Address){}
}