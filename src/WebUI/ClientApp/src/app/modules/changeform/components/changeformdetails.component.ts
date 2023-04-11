import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApplicantClient, ApplicationType } from 'src/app/web-api-client';

@Component({
  selector: 'app-changeformdetails',
  templateUrl: './changeformdetails.component.html',
  styleUrls: ['./changeformdetails.component.css']
})
export class ChangeformdetailsComponent {
  changeForm: FormGroup;
  submitted = false;
  loading: boolean = false;
  message: number | any;
  newFormType: string | any;
  //formtype: ApplicationType[] = [];
  forms = ApplicationType;
  formKeys = [];
  formTypes = Object.values(this.forms).filter(value => typeof value === 'string').sort((lhs, rhs) => lhs[1] - rhs[1])


  ngOnInit() {

    this.changeForm = this.fb.group({

      oldForm: ['', Validators.required],
      FormType: ['', Validators.required],

    });
  }
  constructor(private fb: FormBuilder, private client: ApplicantClient) {
    /* client.getForms().subscribe((data: ApplicationType[]): void => {
      this.formtype = data;
      console.log("religions", this.formtype);
    }) */

    this.formKeys = Object.keys(this.formTypes);
  }


  onSubmit() {
    if (this.changeForm.invalid) {
      return;
    }
    this.loading = true;
    this.newFormType = this.forms[this.changeForm.get('FormType').value];
    this.client.saveFormChanges(this.changeForm.value).subscribe(data => {
      this.message = data;
      this.loading = false;

      console.log("response is " + JSON.stringify(data))
    },
      error => this.message = error,
      () => this.loading = false,

    );
  }
}
