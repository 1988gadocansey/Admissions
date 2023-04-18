import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExamDto, GradeDto, ResultUploadClient, ResultsDto, SelectBoxClient, SubjectDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-resultuploaddetails',
  templateUrl: './resultuploaddetails.component.html',
  styleUrls: ['./resultuploaddetails.component.css']
})
export class ResultuploaddetailsComponent {
  ResultUploadForm: FormGroup;
  submitted = false;
  loading: boolean = false;
  message: number | any;
  resultUploadDto: ResultsDto[]
  public exams: ExamDto[] = [];
  public subjects: SubjectDto[] = [];
  public grades: GradeDto[] = [];
  selectedYear: number;
  years: number[] = [];
  ngOnInit() {
    this.loading = true;
    this.resultUploadClient.get(1, 1, 100).subscribe(
      result => {
        this.resultUploadDto = result.items;
        this.loading = false;
      },
      error => console.error(error)
    );

    this.ResultUploadForm = this.fb.group({
      Id: [''],
      SubjectId: ['', Validators.required],
      ExamType: ['', Validators.required],
      GradeID: ['', Validators.required],
      Center: ['', Validators.required],
      Year: ['', Validators.required],
      IndexNo: ['', Validators.required],
      Sitting: ['', Validators.required],
      Month: ['', Validators.required],
    });
  }

  constructor(private fb: FormBuilder, private resultUploadClient: ResultUploadClient, private client: SelectBoxClient,) {
    client.getSubjects().subscribe((data: SubjectDto[]) => {
      this.subjects = data;
      console.log("programmes", this.subjects);
    })

    client.getExams().subscribe((data: ExamDto[]) => {
      this.exams = data;
      console.log("exams", this.exams);
    })

    client.getGrades().subscribe((data: GradeDto[]) => {
      this.grades = data;
      console.log("grades", this.grades);
    })

    this.selectedYear = new Date().getFullYear();
    for (let year = this.selectedYear; year >= 1955; year--) {
      this.years.push(year);
    }

  }

  onSubmit(): void {

    if (this.ResultUploadForm.invalid) {
      return;
    }
    this.loading = true;
    console.log("data", this.ResultUploadForm.value);
    this.resultUploadClient.create(this.ResultUploadForm.value).subscribe(data => {
      this.message = data;
      this.loading = false;
      window.location.href = '/proof/preview';
      console.log("response is " + JSON.stringify(data))
    },
      error => this.message = error,
      () => this.loading = false,

    );
  }

}
