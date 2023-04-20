import { Component } from '@angular/core';
import { ApplicantClient, ApplicantVm, HomeClient, UserDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-previewdetails',
  templateUrl: './previewdetails.component.html',
  styleUrls: ['./previewdetails.component.css']
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
  constructor(private applicantClient: ApplicantClient, private client: HomeClient) {

  }
  ngOnInit() {
    this.loading = true;
    this.getGrade();
    this.getUser();
    this.applicantClient.get().subscribe(data => {
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
  }

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
}
