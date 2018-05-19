import { MedicalUnit } from "./medicalUnit";
import { BloodDonation } from "./bloodDonation";

export class BloodBank{
    id:number;
    medicalUnit:MedicalUnit;
    bloodDonations:BloodDonation[];
}