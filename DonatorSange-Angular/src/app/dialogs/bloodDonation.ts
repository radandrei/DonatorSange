import { DonorService } from "../services/donor.service";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Inject } from "@angular/core";

export class BloodDonation{

    constructor(public dialogRef: MatDialogRef<BloodDonation>,public donorService:DonorService,@Inject(MAT_DIALOG_DATA) public data: any){
        
    }

}