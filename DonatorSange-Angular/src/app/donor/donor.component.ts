import { Component, OnInit } from '@angular/core';
import { DonorService } from '../services/donor.service';
import { Address } from '../models/address';
import { Donor } from '../models/donor';
import { Constants } from '../utils/constants';
import { DonationRequest } from '../models/donationRequest';
import { FormHelperService } from '../services/form-helper.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomValidators } from "ng2-validation/dist";

@Component({
  selector: 'app-donor',
  templateUrl: './donor.component.html',
  styleUrls: ['./donor.component.css'],
  providers : [DonorService, FormHelperService]
})
export class DonorComponent implements OnInit {
  donorForm: FormGroup;
  isSucceded = null;
  donorModel: Donor = Donor.initialize();
  genders = Constants.genders;
  countries = Constants.country_list;
  hasRecipientName = false;
  constructor(private donorService:DonorService, private formHelperService: FormHelperService, private formBuilder: FormBuilder) { }
  
  ngOnInit() {
    let loggedUser = JSON.parse(localStorage.getItem("myUser"));
    this.donorModel.gender = this.genders[0];
    this.donorModel.user.id = loggedUser.id;
    this.donorModel.user.firstName = loggedUser.firstName;
    this.donorModel.user.lastName = loggedUser.lastName;
    this.donorForm = this.formBuilder.group({
      birthdate:['', [Validators.required]],
      phone: ['', [Validators.required, Validators.maxLength(15)]],
      email: ['', [Validators.required, CustomValidators.email, Validators.maxLength(100)]],
      city: ['', [Validators.required, Validators.maxLength(20)]],
      county: ['', [Validators.required, Validators.maxLength(20)]],
      street: ['', [Validators.required, Validators.maxLength(50)]],
      number: ['', [Validators.required, Validators.min(0)]]
    });
  }

  donate(){
    let serializedModel = JSON.stringify(this.donorModel);
    this.donorService.add(serializedModel).subscribe(result=>{
      this.isSucceded = true;
    },()=>{
      this.isSucceded = false;
    });
  }

  showErrorMessage(form: FormGroup, controlName: string, validator: string): boolean {
    return this.formHelperService.showErrorMessage(form, controlName, validator)
  }

}
