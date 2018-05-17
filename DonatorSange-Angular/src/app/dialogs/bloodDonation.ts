import { DonationService } from "../services/donation.service";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Inject } from "@angular/core";
import { BloodComponent } from "../models/bloodComponent";
import { BloodComponentQuantity } from "../models/bloodComponentQuantity";

export class BloodDonation {

    bloodComponents;
    quantity;
    componentQuantities;

    constructor(public dialogRef: MatDialogRef<BloodDonation>, public donationService: DonationService, @Inject(MAT_DIALOG_DATA) public data: any) {
        donationService.getBloodComponents().subscribe(
            response => {
                this.bloodComponents = response;
            }
        );

        this.bloodComponents.array.forEach(element => {
            this.componentQuantities().push(new BloodComponentQuantity(element.id, 0))
        });

    }

}