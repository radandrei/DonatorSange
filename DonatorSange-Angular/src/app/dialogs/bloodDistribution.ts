import { Component, Inject } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { RequestService } from "../services/request.service";
import { MedicalRequest } from "../models/medicalrequest";


@Component({
  selector: 'blood-distribution',
  templateUrl: '/bloodDistribution.html',
  styleUrls: ['/bloodDistribution.css'],
  providers: [RequestService]
})

export class DialogDistribution {
    request:MedicalRequest;
    depositedQuantity:number;
    confirmation;
  constructor(public dialogRef: MatDialogRef<DialogDistribution>,public requestService:RequestService,@Inject(MAT_DIALOG_DATA) public data: any) {
    this.requestService.getRequest(data.requestId).subscribe(request=>{
      this.request=request;
    }
    )
    this.requestService.getBloodComponentTypeQuantity(data.bloodComponentTypeId,data.medicalUnitId).subscribe(quantity=>{
      this.depositedQuantity=quantity;
    })
  }

  edit(distributionQuantity) {
      let quantityNeeded=this.request.quantity;
      if(distributionQuantity<=quantityNeeded){
    this.request.quantity=quantityNeeded-distributionQuantity;
    this.requestService.updateRequest(this.request,distributionQuantity).subscribe(
      response => {
        window.location.reload();
        alert("Data updated!");
      },
      error => {
        alert("Data update issue!");
      }

    ); // the call
}
else
    alert("They don't need that much blood.");
  }
  cancel() {
    ;
  }
}