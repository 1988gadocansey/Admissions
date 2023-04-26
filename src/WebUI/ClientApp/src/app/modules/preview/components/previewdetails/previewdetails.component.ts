import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, LOCALE_ID } from '@angular/core';
import { AddressClient, AddressDto, ApplicantClient, ApplicantVm, EducationalBackendClient, Gender, HomeClient, PreviewClient, ProgrammeDto, ProgrammeInformationClient, ResultUploadClient, ResultsDto, SHSAttendedDto, UniversityAttendedDto, UserDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-previewdetails',
  templateUrl: './previewdetails.component.html',
  styleUrls: ['./previewdetails.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PreviewdetailsComponent {
  submitted = false;
  loading: boolean = false;
  message: number | any;
  applicant: ApplicantVm;
  public imgurl: string;
  public imgurlAlt: string;
  grade: any = null;
  user: UserDto;
  addressDto: AddressDto
  choice: string | null;
  resultUploadDto: ResultsDto[];
  shsAttended: SHSAttendedDto;
  public universityAttended: UniversityAttendedDto;
  constructor(private applicantClient: ApplicantClient, private client: HomeClient, private academicClient: ProgrammeInformationClient, private educationalInformationClient: EducationalBackendClient, private previewClient: PreviewClient, private resultUploadClient: ResultUploadClient, private addressClient: AddressClient) {

  }
  ngOnInit() {
    this.loading = true;
    this.getGrade();
    this.getUser();
    this.getAddress();
    this.getUniversityAttended();
    this.getSHSInfo();
    this.getResults();
    this.previewClient.getPreview().subscribe(data => {
      this.message = data;
      this.loading = false;
      this.applicant = data;
      this.imgurl = "https://photos.ttuportal.com/public/albums/thumbnails/" +
        this.applicant.applicationNumber.applicantNumber + ".jpg";
      this.imgurlAlt = "https://photos.ttuportal.com/public/albums/thumbnails/" +
        this.applicant.applicationNumber.applicantNumber + ".jpeg";
      console.log("response is " + JSON.stringify(data))
    },
      error => this.message = error,
      () => this.loading = false,

    );
    this.genderKeys = Object.keys(this.genderTypes);

  }
  gender = Gender;
  genderKeys = [];
  genderTypes = Object.values(this.gender).filter(value => typeof value === 'number');

  getGrade() {
    this.client.getGrade().subscribe({
      next: data => {
        this.grade = data;
      }
    })
  }
  getUser() {
    this.client.dashboard().subscribe({
      next: data => {
        this.user = data;
      }
    })
  }
  getSHSInfo() {
    this.previewClient.getSHS().subscribe(
      result => {
        this.shsAttended = result;
        console.log("shs attended" + this.shsAttended.name)
        // this.loading = false;
      },
      error => {
        this.message = JSON.parse(error.response);

        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }
  getUniversityAttended() {
    this.previewClient.getUniversity().subscribe(
      result => {
        this.universityAttended = result;
        this.loading = false;
      },
      error => {
        this.message = JSON.parse(error.response);

        this.loading = false,

          setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }
  getAddress() {
    this.addressClient.get().subscribe(
      result => {
        this.addressDto = result;
      },
      error => {
        this.message = JSON.parse(error.response);
        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }
  getResults() {
    this.resultUploadClient.get(1, 1, 100).subscribe(
      result => {
        this.resultUploadDto = result.items;
      },
      error => {
        this.message = JSON.parse(error.response);
        setTimeout(() => document.getElementById('title').focus(), 250);
      }
    );
  }


}
