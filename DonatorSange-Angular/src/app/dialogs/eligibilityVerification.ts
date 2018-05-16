import { Component, Inject } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { DonorData } from "../models/donorData";
import { DonorService } from "../services/donor.service";


@Component({
  selector: 'eligibility-verification',
  templateUrl: '/eligibilityVerification.html',
  styleUrls: ['/eligibilityVerification.css'],
  providers: []
})
export class DialogVerifyEligibiliy {

    birthDate;
    weight;
    heartBeat;
    bloodPressure;
    interventions;
    feminineProblems;
    junkFood;
    onDrugs;
    diseases;
    donorId;
    donorData;
    donor;


  constructor(public dialogRef: MatDialogRef<DialogVerifyEligibiliy>,public donorService:DonorService,@Inject(MAT_DIALOG_DATA) public data: any) {
    this.donorId=data.donorId;
    this.donorService.getDonor(this.donorId).subscribe(donor=>{
      this.donor=donor;
      this.donorData=donor.donorData;
      this.weight=donor.donorData.weight;
      this.heartBeat=donor.donorData.heartBeat;
      this.bloodPressure=donor.donorData.bloodPressure;
      this.interventions=donor.donorData.interventions;
      this.feminineProblems=donor.donorData.feminineProblems;
      this.junkFood=donor.donorData.junkFood;
      this.onDrugs=donor.donorData.onDrugs;
      this.diseases=donor.donorData.diseases;
    }
    )
    
  }

  resolveEligibility(birthDate,weight,heartBeat,bloodPreassure,interventions,feminineProblems,junkFood,onDrugs,diseases){
    let year=1000*60*60*24*365;
    let birthDateValidation = (birthDate.getTime()>(new Date().getTime()+year*18&&birthDate.getTime()<(new Date().getTime()+year*60)));
    let weightValidation=(weight>50);
    let heartBeatValidation=(heartBeat>60&&heartBeat<100);
    let bloodPreassureValidation=(bloodPreassure>100&&bloodPreassure<180);
    let finalResult=(birthDateValidation&&weightValidation&&heartBeatValidation&&bloodPreassureValidation&&!interventions&&!feminineProblems&&!junkFood&&!onDrugs&&!diseases)
    return finalResult;
  }

  add(birthDate,weight,heartBeat,bloodPreassure,interventions,feminineProblems,junkFood,onDrugs,diseases) {
    if (weight==""||birthDate == "" || bloodPreassure == "" || interventions == "" || feminineProblems == ""||junkFood=="" || this.onDrugs=="" || this.diseases=="") {
      alert("The fields are not complete! The donation is at risk.");
      return "error";
    }

    this.donorData.weight=weight;
    this.donorData.birthDate=birthDate;
    this.donorData.heartBeat=heartBeat;
    this.donorData.bloodPreassure=bloodPreassure;
    this.donorData.interventions=interventions;
    this.donorData.feminineProblems=feminineProblems;
    this.donorData.junkFood=junkFood;
    this.donorData.onDrugs=onDrugs;
    this.donorData.diseases=diseases;
    
    this.donorService.updateDonorData(this.donorData).subscribe(
      response => {
        window.location.reload();
        alert("Data updated!");
      },
      error => {
        alert("Medic creation issue!");
      }

    ); // the call
  }
  cancel() {
    ;
  }
}