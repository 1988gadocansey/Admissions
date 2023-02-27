import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Injectable } from '@angular/core';
import { FormGroup, FormControl, Validators, NgForm } from '@angular/forms';
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

  file: File = null; // Variable to store file


  // Inject service 
  constructor(private fileUploadService: FileUploadService) { }

  ngOnInit(): void {
  }

  // On file Select
  onChange(event) {
    this.file = event.target.files[0];
  }

  // OnClick of button Upload
  onUpload() {
    this.loading = !this.loading;
    console.log(this.file);
    this.fileUploadService.upload(this.file).subscribe(resp => {
      alert(resp)
    });
  }

}
