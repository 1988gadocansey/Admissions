import { Component, ElementRef, NgModule, OnInit, ViewChild } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthResponseDto } from '../core/models/response/authResponseDto.model';
import { UserForAuthenticationDto } from '../core/models/user/userForAuthenticationDto.model';
import { Router, ActivatedRoute } from '@angular/router';

import { ViewEncapsulation } from '@angular/core'
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ExternalAuthDto } from '../core/models/externalAuth/externalAuthDto.model'
import { NONE_TYPE } from '@angular/compiler';

@Component({

  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']

})
export class HomeComponent {
  //public title: string = "";


}


