import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { Observable, tap, catchError, throwError } from 'rxjs';
import { Session, ApplicantVm, EntryQualification, ProgrammeDto, SelectBoxClient, BiodataClient, ApplicantClient, ProgrammeInformationClient, SHSAttendedDto, RegionDto, EducationalBackendClient, SHSProgrammesDto, SubjectDto, FormerSchoolDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-educationalbackgrounddetails',
  templateUrl: './educationalbackgrounddetails.component.html',
  styleUrls: ['./educationalbackgrounddetails.component.css']
})
export class EducationalbackgrounddetailsComponent {
  shsform: FormGroup;
  universityForm: FormGroup;
  submitted = false;
  loading: boolean = false;
  message: number | any;
  applicant: ApplicantVm
    ;
  selectedYear: number;
  years: number[] = [];
  ngOnInit() {

    this.applicantClient.get().subscribe({
      next: data => {
        this.shsform.get("ProgrammeStudied").setValue(data.id);
        this.shsform.get("Location").setValue(data.thirdChoiceId);

      }
    })
    this.shsform = this.fb.group({
      Id: [''],
      Name: ['', Validators.required],
      ProgrammeStudied: ['', Validators.required],
      Location: ['', Validators.required],
      StartYear: ['', Validators.required],
      EndYear: ['', Validators.required],
      FirstChoiceId: ['', Validators.required],
    });


    this.universityForm = this.fb.group({
      Id: [''],
      UniversityAttended: ['', Validators.required],
      Country: ['', Validators.required],
      StartYear: ['', Validators.required],
      EndYears: ['', Validators.required],
      StudentNumber: ['', Validators.required],
      DegreeObtained: ['', Validators.required],
      DegreeClassification: ['', Validators.required],
      CGPA: ['', Validators.required],

    });

  }
  entryMode = Session;
  entryModeKeys = [];
  entryModeTypes = Object.values(this.entryMode).filter(value => typeof value === 'number');

  entryQualification = EntryQualification;
  entryQualificationKeys = [];
  entryQualificationypes = Object.values(this.entryQualification).filter(value => typeof value === 'number');


  public schools: FormerSchoolDto[] = [];
  public programmes: SHSProgrammesDto[] = [];
  public regions: RegionDto[] = [];
  public subjects: SubjectDto[] = [];

  constructor(private fb: FormBuilder, private client: SelectBoxClient, private biodataClient: BiodataClient, private applicantClient: ApplicantClient, private academicClient: ProgrammeInformationClient, private educationalInformationClient: EducationalBackendClient) {
    this.entryModeKeys = Object.keys(this.entryModeTypes);
    this.entryQualificationKeys = Object.keys(this.entryQualificationypes);

    client.getRegions().subscribe((data: RegionDto[]) => {
      this.programmes = data;
      console.log("regions", this.regions);
    })
    client.getSHSProgrammes().subscribe((data: SHSProgrammesDto[]) => {
      this.programmes = data;
      console.log("programmes", this.programmes);
    })

    client.getSubjects().subscribe((data: SubjectDto[]) => {
      this.programmes = data;
      console.log("subjects", this.subjects);
    })
    client.getSchools().subscribe((data: FormerSchoolDto[]) => {
      this.programmes = data;
      console.log("schools", this.schools);
    })


    this.selectedYear = new Date().getFullYear();
    for (let year = this.selectedYear; year >= 1955; year--) {
      this.years.push(year);
    }
  }

  onSubmit(): void {

    if (this.shsform.invalid) {
      return;
    }
    this.loading = true;
    console.log("data", this.shsform.value);
    this.academicClient.create(this.shsform.value).subscribe(data => {
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