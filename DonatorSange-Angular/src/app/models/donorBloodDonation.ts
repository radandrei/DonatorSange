import { BloodComponentQuantity } from "./bloodComponentQuantity";

export class DonorBloodDonation{
    donorId: number;
    bloodComponents: Array<BloodComponentQuantity>;
    diseases: boolean;

    constructor(id:number, components:Array<BloodComponentQuantity>, diseases:boolean){
        this.donorId=id;
        this.bloodComponents=components;
        this.diseases=diseases;
    }
}