import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { FileUploadService } from 'src/app/core/services/fileuploadservice';
import { PictureUploadClient } from 'src/app/web-api-client';

@Component({
  selector: 'app-uploadpic',
  templateUrl: './uploadpic.component.html',
  styleUrls: ['./uploadpic.component.css']
})

export class UploadpicComponent {
  loading: boolean = false; // Flag variable

  // Variable to store shortLink from api response
  shortLink: string = "";
  message: number = 0;
  file: File = null; // Variable to store file



  // Inject service
  constructor(private fileUploadService: FileUploadService, private router: Router) { }

  ngOnInit(): void {
  }

  // On file Select
  onChange(event) {
    this.file = event.target.files[0];
  }

  // OnClick of button Upload
  onUpload() {
    if (this.file == null) {
      return alert("Please select a file to upload");
    }
    this.loading = true;

    console.log(this.file);
    this.fileUploadService.upload(this.file).subscribe(data => {
      this.message = data.status;
      this.loading = false;
      if (data.status == 200) {
        this.router.navigate(['/forms']);
      }
      console.log("response is " + JSON.stringify(data))
    },
      error => console.log(error),
      () => this.loading = false
    );

  }

}
