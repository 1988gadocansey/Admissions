import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HomeClient, UserDto } from 'src/app/web-api-client';

import { RepositoryService } from '../../../../core/services/repository.service';


@Component({
  selector: 'app-topinfo',
  templateUrl: './topinfo.component.html',
  styleUrls: ['./topinfo.component.scss']
})
export class TopinfoComponent {
  public profile: UserDto | any;
  public imgurl: string;
  public imgurlAlt: string;

  constructor(private client: HomeClient) {
    client.dashboard().subscribe(result => {
      this.profile = result;
      this.imgurl = "https://photos.ttuportal.com/public/albums/thumbnails/" +
        this.profile?.formNo + ".jpg";
      this.imgurlAlt = "https://photos.ttuportal.com/public/albums/thumbnails/" +
        this.profile?.formNo + ".jpeg";
      console.log("user is " + this.imgurl);
    }, error => console.error(error));

  }


}
