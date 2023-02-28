import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Gender, Title } from 'src/app/web-api-client';

@Component({
  selector: 'app-biodatadetails',
  templateUrl: './biodatadetails.component.html',
  styleUrls: ['./biodatadetails.component.css']
})
export class BiodatadetailsComponent implements OnInit {
  biodataForm: FormGroup;
  submitted = false;
  ngOnInit() {
    this.biodataForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      previousName: [''],
      otherNames: [''],
      phone: ['', Validators.required],
      altphone: [''],
      dob: ['', Validators.required],
      maritalStatus: ['', Validators.required],
      gender: ['', Validators.required],
      title: ['', Validators.required],
      email: [''],
      emergencyContact: ['', Validators.required],
      hometown: [''],
      district: [''],
      nationalIDType: ['', Validators.required],
      nationalIDNo: ['', Validators.required],
      regionId: ['', Validators.required],
      nationalityId: ['', Validators.required],
      residentialStatus: [''],


      disability: ['', Validators.required],
      disabilityType: ['', Validators.required],
      sourceOfFinance: ['', Validators.required],
      religionId: ['', Validators.required],
      denomination: ['', Validators.required],
      referrals: ['', Validators.required],

      guardianInfo: this.fb.group({
        guardianName: ['', Validators.required],
        guardianPhone: ['', Validators.required],
        guardianOccupation: ['', Validators.required],
        guardianRelationship: ['', Validators.required],
      }),

      address: this.fb.group({
        street: [''],
        city: [''],
        state: [''],
        zip: ['']
      }),

      previousEducationInfo: this.fb.group({
        formerSchoolNewId: ['', Validators.required],
        firstQualification: ['', Validators.required],
        secondQualification: [''],
        programmeStudied: ['', Validators.required],
        lastYearInSchool: ['', Validators.required]
      }),

      programmeChoice: this.fb.group({
        awaiting: ['', Validators.required],
        preferedHall: [''],
        firstChoiceId: ['', Validators.required],
        secondChoiceId: ['', Validators.required],
        thirdChoiceId: ['', Validators.required]
      }),

      sponserShip: this.fb.group({
        sponsorShip: ['', Validators.required],
        sponsorShipCompany: ['', Validators.required],
        sponsorShipLocation: ['', Validators.required],
        sponsorShipCompanyContact: ['', Validators.required]
      }),

    });

  }
  titles = Title;
  titleKeys = [];
  titleTypes = Object.values(this.titles).filter(value => typeof value === 'number');

  gender = Gender;
  genderKeys = [];
  genderTypes = Object.values(this.gender).filter(value => typeof value === 'number');
  constructor(private fb: FormBuilder) {
    this.titleKeys = Object.keys(this.titleTypes);
    this.genderKeys = Object.keys(this.genderTypes);
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.biodataForm.value);
  }
}
