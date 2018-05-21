import { DonationService } from "../services/donation.service";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Inject, Component } from "@angular/core";
import { BloodComponent } from "../models/bloodComponent";
import { BloodComponentQuantity } from "../models/bloodComponentQuantity";

@Component({
    selector: 'blood-donation',
    templateUrl: '/bloodDonation.html',
    styleUrls: ['/bloodDonation.css'],
    providers: [DonationService]
})
export class DialogBloodDonation {
    diseases;
    bloodComponents;
    componentQuantities;
    donorId;

    constructor(public dialogRef: MatDialogRef<DialogBloodDonation>, public donationService: DonationService, @Inject(MAT_DIALOG_DATA) public data: any) {
        this.donorId = data.donorId;

        donationService.getBloodComponents().subscribe(
            response => {
                this.bloodComponents = response;
                this.componentQuantities = new Array<BloodComponentQuantity>();
                this.bloodComponents.forEach(element => {
                    this.componentQuantities.push(new BloodComponentQuantity(element, 0))
                });
            }
        );
    }

    save(diseases) {
        this.donationService.submit(this.donorId, this.componentQuantities, diseases).subscribe(
            response => {
                window.location.reload();
                alert("Data updated!");
              },
              error => {
                alert("Data update issue!");
              }
        );

    }

}