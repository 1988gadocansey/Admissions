import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Session, ApplicantVm, EntryQualification, FormerSchoolDto, SHSProgrammesDto, RegionDto, SubjectDto, SHSAttendedDto, SelectBoxClient, BiodataClient, ApplicantClient, ProgrammeInformationClient, EducationalBackendClient, UniversityAttendedDto, CountryDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-universityattendeddetails',
  templateUrl: './universityattendeddetails.component.html',
  styleUrls: ['./universityattendeddetails.component.css']
})
export class UniversityattendeddetailsComponent {
  universityForm: FormGroup;
  universitiesUrl: string;
  degreesUrl: string;
  submitted = false;
  loading: boolean = false;
  message: number | any;
  applicant: ApplicantVm
  universityData: any;
  degreeData: any;
  ;
  selectedYear: number;
  years: number[] = [];
  ngOnInit() {

    this.loading = true;
    this.getData();
    this.loading = false;

    this.universitiesUrl = '/assets/universities.json';
    this.degreesUrl = '/assets/degrees.json';
    this.http.get(this.universitiesUrl).subscribe(res => {
      this.universityData = res;
    });
    this.http.get(this.degreesUrl).subscribe(res => {
      this.degreeData = res;
    });

    this.universityForm = this.fb.group({
      Id: [''],
      Name: ['', Validators.required],
      Location: ['', Validators.required],
      StartYear: ['', Validators.required],
      EndYear: ['', Validators.required],
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
  public countries: CountryDto[] = [];
  public universityAttended: UniversityAttendedDto[] = [];

  constructor(private fb: FormBuilder, private client: SelectBoxClient, private biodataClient: BiodataClient, private applicantClient: ApplicantClient, private academicClient: ProgrammeInformationClient, private educationalInformationClient: EducationalBackendClient, private http: HttpClient) {
    this.entryModeKeys = Object.keys(this.entryModeTypes);
    this.entryQualificationKeys = Object.keys(this.entryQualificationypes);

    client.getRegions().subscribe((data: RegionDto[]) => {
      this.regions = data;
      console.log("regions", this.regions);
    })
    client.getSHSProgrammes().subscribe((data: SHSProgrammesDto[]) => {
      this.programmes = data;
      console.log("programmes", this.programmes);
    })
    client.getCountries().subscribe((data: CountryDto[]) => {
      this.countries = data;
      console.log("programmes", this.countries);
    })

    client.getSubjects().subscribe((data: SubjectDto[]) => {
      this.subjects = data;
      console.log("subjects", this.subjects);
    })
    client.getSchools().subscribe((data: FormerSchoolDto[]) => {
      this.schools = data;
      console.log("schools", this.schools);
    })


    this.selectedYear = new Date().getFullYear();
    for (let year = this.selectedYear; year >= 1955; year--) {
      this.years.push(year);
    }
  }

  onSubmit(): void {

    if (this.universityForm.invalid) {
      return;
    }
    this.loading = true;
    console.log("data", this.universityForm.value);
    this.educationalInformationClient.createUniversity(this.universityForm.value).subscribe(data => {
      this.message = data;
      this.loading = false;
      this.getData();
      console.log("response is " + JSON.stringify(data))
    },
      error => this.message = error,
      () => this.loading = false,

    );
  }
  getData() {
    this.educationalInformationClient.getUniversity(1, 1, 100).subscribe(
      result => {
        this.universityAttended = result.items;
        this.loading = false;
      },
      error => {
        this.message = JSON.parse(error.response);

        this.loading = false,

          setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }

  delete(id: number): void {

    var c = confirm("Are you sure you want to delete this info?");

    if (c == true) {
      this.educationalInformationClient.deleteUniversity(id).subscribe(data => {
        this.getData();
      }
      );

    }

  }
}
