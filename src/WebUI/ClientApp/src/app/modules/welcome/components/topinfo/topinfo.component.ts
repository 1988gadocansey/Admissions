import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HomeClient } from 'src/app/web-api-client';

import { RepositoryService } from '../../../../core/services/repository.service';


@Component({
  selector: 'app-topinfo',
  templateUrl: './topinfo.component.html',
  styleUrls: ['./topinfo.component.scss']
})
export class TopinfoComponent {
  public profile: HomeClient |any;
  constructor(private client: HomeClient) {
    client. dashboard().subscribe(result => {
      this.profile = result;
    }, error => console.error(error));

  }


}
