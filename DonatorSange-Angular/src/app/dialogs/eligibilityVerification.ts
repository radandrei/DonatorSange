import { Component, Inject } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { DonorData } from "../models/donorData";
import { DonorService } from "../services/donor.service";


@Component({
  selector: 'eligibility-verification',
  templateUrl: '/eligibilityVerification.html',
  styleUrls: ['/eligibilityVerification.css'],
  providers: [DonorService]
})
export class DialogVerifyEligibility {
  birthdate;
  weight;
  heartbeat;
  bloodPressure;
  interventions;
  feminineProblems;
  junkFood;
  onDrugs;
  diseases;
  donorId;
  donorData;
  donor;
  date;
  confirm;
  confirmation = false;

  constructor(public dialogRef: MatDialogRef<DialogVerifyEligibility>, public donorService: DonorService, @Inject(MAT_DIALOG_DATA) public data: any) {
    this.donorId = data.donorId;
    this.donorService.getDonor(this.donorId).subscribe(donor => {
      this.donor = donor;
      this.donorData = donor.donorData;
    })

  }

  resolveEligibility(birthdate, weight, heartbeat, bloodPressure, interventions, feminineProblems, junkFood, onDrugs, diseases) {
    let year = 1000 * 60 * 60 * 24 * 365;
    let donorTime = new Date(birthdate).getTime();
    let actualTime = new Date().getTime();
    let birthDateValidation = (donorTime + 18 * year < actualTime && donorTime + 60 * year > actualTime)
    let weightValidation = (weight > 50);
    let heartBeatValidation = (heartbeat > 60 && heartbeat < 100);
    let bloodPreassureValidation = (bloodPressure > 100 && bloodPressure < 180);
    let finalResult = (birthDateValidation && weightValidation && heartBeatValidation && bloodPreassureValidation && interventions && feminineProblems && junkFood && onDrugs && diseases)
    return finalResult;
  }

  add(birthdate, weight, heartbeat, bloodPressure, interventions, feminineProblems, junkFood, onDrugs, diseases) {
    this.donorData.weight = weight;
    this.donorData.birthdate = birthdate;
    this.donorData.heartBeat = heartbeat;
    this.donorData.bloodPreassure = bloodPressure;
    this.donorData.interventions = !interventions;
    this.donorData.feminineProblems = !feminineProblems;
    this.donorData.junkFood = !junkFood;
    this.donorData.onDrugs = !onDrugs;
    this.donorData.diseases = !diseases;

    this.donor.donorData = this.donorData;
    this.donorService.updateDonor(this.donor).subscribe(
      response => {
        window.location.reload();
        alert("Data updated!");
      },
      error => {
        alert("Data update issue!");
      }

    ); // the call
  }
  cancel() {
    ;
  }
}