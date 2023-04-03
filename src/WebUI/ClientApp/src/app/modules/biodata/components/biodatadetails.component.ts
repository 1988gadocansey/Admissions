import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Observable, catchError, retry, tap, throwError } from 'rxjs';
import { ApplicantClient, ApplicantVm, BiodataClient, CountryDto, CreateBiodataRequest, DenominationDto, Disability, DistrictDto, Gender, IDCards, MaritalStatus, RegionDto, ReligionDto, SelectBoxClient, Title } from 'src/app/web-api-client';

@Component({
  selector: 'app-biodatadetails',
  templateUrl: './biodatadetails.component.html',
  styleUrls: ['./biodatadetails.component.css']
})
export class BiodatadetailsComponent implements OnInit {
  biodataForm: FormGroup;
  submitted = false;
  loading: boolean = false;
  message: number | any;
  applicant: ApplicantVm
    ;
  ngOnInit() {

    this.applicantClient.get().subscribe({
      next: data => {
        this.applicant = data,
          this.biodataForm.get("email").setValue(data.email.value);
        this.biodataForm.get("Id").setValue(data.id);
        this.biodataForm.get("firstName").setValue(data.applicantName.firstName);
        this.biodataForm.get("lastName").setValue(data.applicantName.lastName);
        this.biodataForm.get("otherNames").setValue(data.applicantName.othernames);
        this.biodataForm.get("previousName").setValue(data.previousName.firstName);
        this.biodataForm.get("title").setValue(data.title);
        this.biodataForm.get("gender").setValue(data.gender);
        this.biodataForm.get("phone").setValue(data.phone.number);
        this.biodataForm.get("hometown").setValue(data.hometown);
        this.biodataForm.get("maritalStatus").setValue(data.maritalStatus);
        this.biodataForm.get("regionId").setValue(data.regionId);
        this.biodataForm.get("religionId").setValue(data.religionId);
        this.biodataForm.get("denomination").setValue(data.denomination);
        this.biodataForm.get("sourceOfFinance").setValue(data.sourceOfFinance);
        this.biodataForm.get("disability").setValue(data.disability);
        this.biodataForm.get("disabilityType").setValue(data.disabilityType);
        this.biodataForm.get("guardianName").setValue(data.guardianName);
        this.biodataForm.get("guardianOccupation").setValue(data.guardianOccupation);
        this.biodataForm.get("guardianPhone").setValue(data.guardianPhone.number);
        this.biodataForm.get("guardianRelationship").setValue(data.guardianRelationship);
        this.biodataForm.get("altphone").setValue(data.altPhone.number);
        this.biodataForm.get("emergencyContact").setValue(data.emergencyContact.number);
        this.biodataForm.get("referrals").setValue(data.referrals);
        this.biodataForm.get("district").setValue(data.districtId);
        this.biodataForm.get("nationalIDType").setValue(data.idCard.nationalIDType);
        this.biodataForm.get("nationalIDNo").setValue(data.idCard.nationalIDNo);
        this.biodataForm.get("sponsorShip").setValue(data.sponsorShip);
        this.biodataForm.get("sponsorShipCompany").setValue(data.sponsorShipCompany);
        this.biodataForm.get("sponsorShipLocation").setValue(data.sponsorShipLocation);
        this.biodataForm.get("sponsorShipCompanyContact").setValue(data.sponsorShipCompanyContact);
        this.biodataForm.get("residentialStatus").setValue(data.residentialStatus);
        this.biodataForm.get("day").setValue(data.dob);
        this.biodataForm.get("nationalityId").setValue(data.nationalityId);
      }
    })


    this.biodataForm = this.fb.group({
      Id: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      previousName: [''],
      otherNames: [''],
      phone: ['', Validators.required],
      altphone: [''],
      day: ['', Validators.required],
      year: ['', Validators.required],
      month: ['', Validators.required],
      maritalStatus: ['', Validators.required],
      gender: ['', Validators.required],
      title: ['', Validators.required],
      email: [''],
      emergencyContact: ['', Validators.required],
      hometown: ['', Validators.required],
      district: ['', Validators.required],
      nationalIDType: ['', Validators.required],
      nationalIDNo: ['', Validators.required],
      regionId: ['', Validators.required],
      nationalityId: ['', Validators.required],
      residentialStatus: ['', Validators.required],
      disability: ['', Validators.required],
      disabilityType: ['', Validators.required],
      sourceOfFinance: ['', Validators.required],
      religionId: ['', Validators.required],
      denomination: [''],
      referrals: ['', Validators.required],
      sponsorShip: ['', Validators.required],
      sponsorShipCompany: ['', Validators.required],
      sponsorShipLocation: ['', Validators.required],
      sponsorShipCompanyContact: ['', Validators.required],
      guardianName: ['', Validators.required],
      guardianPhone: ['', Validators.required],
      guardianOccupation: ['', Validators.required],
      guardianRelationship: ['', Validators.required],
      /* address: this.fb.group({
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
 */


    });

  }
  get primEmail() {
    return this.biodataForm.get('email')
  }
  disabilities = Disability;
  disabilitiesKeys = [];
  disabilitiesTypes = Object.values(this.disabilities).filter(value => typeof value === 'number');

  titles = Title;
  titleKeys = [];
  titleTypes = Object.values(this.titles).filter(value => typeof value === 'number');

  gender = Gender;
  genderKeys = [];
  genderTypes = Object.values(this.gender).filter(value => typeof value === 'number');

  IdCard = IDCards;
  IdCardKeys = [];
  IdCardTypes = Object.values(this.IdCard).filter(value => typeof value === 'number');

  maritalStatus = MaritalStatus;
  maritalKeys = [];
  maritalTypes = Object.values(this.maritalStatus).filter(value => typeof value === 'number');

  /* monthList = Array.from({ length: 12 }, (item, i) => {
    return new Date(0, i).toLocaleString('en-US', { month: 'long' })
  }); */
  public religions: ReligionDto[] = [];
  public regions: RegionDto[] = [];
  public districts: DistrictDto[] = [];
  public nationalities: CountryDto[] = [];
  public denominations: DenominationDto[] = [];
  selectedYear: number;
  years: number[] = [];

  days = Array.from({ length: 31 }, (item, index) => index + 1);


  constructor(private fb: FormBuilder, private client: SelectBoxClient, private biodataClient: BiodataClient, private applicantClient: ApplicantClient) {
    this.titleKeys = Object.keys(this.titleTypes);
    this.genderKeys = Object.keys(this.genderTypes);
    this.IdCardKeys = Object.keys(this.IdCardTypes);
    this.disabilitiesKeys = Object.keys(this.disabilitiesTypes);
    this.maritalKeys = Object.keys(this.maritalTypes);
    this.selectedYear = 2005;
    for (let year = this.selectedYear; year >= 1945; year--) {
      this.years.push(year);
    }
    client.getRegions().subscribe((data: RegionDto[]) => {
      this.regions = data;
      console.log("religions", this.regions);
    })
    client.getCountries().subscribe((data: CountryDto[]) => {
      this.nationalities = data;
      console.log("countries", this.nationalities);
    })
    client.getDistricts().subscribe((data: DistrictDto[]) => {
      this.districts = data;
      console.log("districts", this.districts);
    })

    client.getDenominations().subscribe((data: DenominationDto[]) => {
      this.denominations = data;
      console.log("denomination", this.denominations);
    })
    client.getReligions().subscribe((data: ReligionDto[]) => {
      this.religions = data;
      console.log("religions", this.religions);
    })



  }

  onSubmit(): void {

    this.loading = true;
    console.log("data", this.biodataForm.value);
    this.biodataClient.create(this.biodataForm.value).subscribe(data => {
      this.message = data;
      this.loading = false;
      console.log("response is " + JSON.stringify(data))
    },
      error => this.message = error,
      () => this.loading = false,

    );
  }

  getApplicant(): Observable<ApplicantVm> {
    return this.applicantClient.get().pipe(
      tap(data => console.log('All: ' + JSON.stringify(data))),
      catchError(this.handleError)
    );

  }
  private handleError(err: HttpErrorResponse) {

    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {

      errorMessage = `An error occurred: ${err.error.message}`;
    } else {

      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    console.error(errorMessage);
    return throwError(errorMessage);
  }
}