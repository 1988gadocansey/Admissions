import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, catchError, tap } from 'rxjs';
import { AddressClient, AddressDto } from 'src/app/web-api-client';

@Component({
  selector: 'app-addressdetails',
  templateUrl: './addressdetails.component.html',
  styleUrls: ['./addressdetails.component.css']
})
export class AddressdetailsComponent {
  AddressInfo: FormGroup;
  submitted = false;
  loading: boolean = false;
  message: number | any;
  addressDto: AddressDto


  ngOnInit() {

    this.addressClient.get().subscribe({
      next: data => {
        this.AddressInfo.get("Id").setValue(data.id);
        this.AddressInfo.get("Street").setValue(data.street);
        this.AddressInfo.get("HouseNumber").setValue(data.houseNumber);
        this.AddressInfo.get("City").setValue(data.city);
        this.AddressInfo.get("GPRS").setValue(data.gprs);
        this.AddressInfo.get("Box").setValue(data.box);

      }
    })

    this.AddressInfo = this.fb.group({
      Id: [''],
      Street: ['', Validators.required],
      HouseNumber: ['', Validators.required],
      City: ['', Validators.required],
      GPRS: ['', Validators.required],
      Box: ['', Validators.required],
    });
  }

  constructor(private fb: FormBuilder, private addressClient: AddressClient) {

  }
  onSubmit(): void {

    if (this.AddressInfo.invalid) {
      return;
    }
    this.loading = true;
    console.log("data", this.AddressInfo.value);
    this.addressClient.create(this.AddressInfo.value).subscribe(data => {
      this.message = data;
      this.loading = false;
      window.location.href = '/stepthree/academics';
      console.log("response is " + JSON.stringify(data))
    },
      error => this.message = error,
      () => this.loading = false,

    );
  }


}
