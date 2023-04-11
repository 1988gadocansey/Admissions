import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DateAsAgoPipe } from 'src/app/core/pipes/datePipe';
import { HomeClient, UserDto } from 'src/app/web-api-client';

import { RepositoryService } from '../../../../core/services/repository.service';


@Component({
  selector: 'app-topinfo',
  templateUrl: './topinfo.component.html',
  styleUrls: ['./topinfo.component.scss'],
  providers: [DateAsAgoPipe]
})
export class TopinfoComponent {
  public profile: UserDto | any;
  public imgurl: string;
  public imgurlAlt: string;
  loading: boolean = false; // Flag variable

  constructor(private client: HomeClient, private dateago: DateAsAgoPipe) {
    client.dashboard().subscribe(result => {
      this.loading = true;
      this.profile = result;
      this.imgurl = "https://photos.ttuportal.com/public/albums/thumbnails/" +
        this.profile?.formNo + ".jpg";
      this.imgurlAlt = "https://photos.ttuportal.com/public/albums/thumbnails/" +
        this.profile?.formNo + ".jpeg";
      this.loading = false;
      // console.log("user is " + this.imgurl);
    }, error => console.error(error)), this.loading = false;

  }


}
