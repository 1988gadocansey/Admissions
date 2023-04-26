
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Observable, catchError, tap, throwError } from 'rxjs';
import { ApplicantClient, ApplicantVm, BiodataClient, EntryQualification, ProgrammeDto, ProgrammeInformationClient, SelectBoxClient, Session } from 'src/app/web-api-client';

@Component({
  selector: 'app-academiccomponent',
  templateUrl: './academiccomponent.component.html',
  styleUrls: ['./academiccomponent.component.css']
})
export class AcademiccomponentComponent implements OnInit {
  programmeInfo: FormGroup;
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
        this.programmeInfo.get("Id").setValue(data.id);
        this.programmeInfo.get("ThirdChoiceId").setValue(data.thirdChoiceId);
        this.programmeInfo.get("FirstChoiceId").setValue(data.thirdChoiceId);
        this.programmeInfo.get("SecondChoiceId").setValue(data.secondChoiceId);
        this.programmeInfo.get("entryMode").setValue(this.entryMode[data.entryMode]);
        this.programmeInfo.get("awaiting").setValue(data.awaiting);
        this.programmeInfo.get("indexNo").setValue(data.indexNo);
        this.programmeInfo.get("lastYearInSchool").setValue(data.lastYearInSchool);
        this.programmeInfo.get("firstQualification").setValue(this.entryQualification[data.firstQualification]);
        this.programmeInfo.get("secondQualification").setValue(this.entryQualification[data.secondQualification]);
      }
    })


    this.programmeInfo = this.fb.group({
      Id: [''],
      firstQualification: ['', Validators.required],
      secondQualification: ['', Validators.required],

      entryMode: ['', Validators.required],

      indexNo: [''],

      ThirdChoiceId: ['', Validators.required],
      SecondChoiceId: ['', Validators.required],
      FirstChoiceId: ['', Validators.required],
      lastYearInSchool: ['', Validators.required],
      awaiting: ['', Validators.required],



    });

  }

  entryMode = Session;
  entryModeKeys = [];
  entryModeTypes = Object.values(this.entryMode).filter(value => typeof value === 'number');

  entryQualification = EntryQualification;
  entryQualificationKeys = [];
  entryQualificationypes = Object.values(this.entryQualification).filter(value => typeof value === 'number');


  public programmes: ProgrammeDto[] = [];



  constructor(private fb: FormBuilder, private client: SelectBoxClient, private biodataClient: BiodataClient, private applicantClient: ApplicantClient, private academicClient: ProgrammeInformationClient) {
    this.entryModeKeys = Object.keys(this.entryModeTypes);
    this.entryQualificationKeys = Object.keys(this.entryQualificationypes);

    client.getProgrammes().subscribe((data: ProgrammeDto[]) => {
      this.programmes = data;
      console.log("programmes", this.programmes);
    })
    this.selectedYear = new Date().getFullYear();
    for (let year = this.selectedYear; year >= 1955; year--) {
      this.years.push(year);
    }
  }

  onSubmit(): void {

    if (this.programmeInfo.invalid) {
      return;
    }
    this.loading = true;
    console.log("data", this.programmeInfo.value);
    this.academicClient.create(this.programmeInfo.value).subscribe(data => {
      this.message = data;
      this.loading = false;
      window.location.href = '/stepfour/educationalbackground';
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