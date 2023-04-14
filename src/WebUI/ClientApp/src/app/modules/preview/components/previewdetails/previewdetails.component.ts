import { Component } from '@angular/core';
import { ApplicantClient, ApplicantVm } from 'src/app/web-api-client';

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
  constructor(private applicantClient: ApplicantClient) {

  }
  ngOnInit() {
    this.loading = true;
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
}
