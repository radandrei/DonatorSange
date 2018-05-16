import { Donor } from "./donor";
import {BloodType } from "./bloodType";

export class DonorData{
    id:number;
    birthdate:Date;
    bloodType:BloodType;
    weight:number;
    heartBeat:number;
    bloodPressure:number;
    interventions:boolean;
    feminineProblems:boolean;
    junkFood:boolean;
    onDrugs:boolean;
    diseases:boolean;
}