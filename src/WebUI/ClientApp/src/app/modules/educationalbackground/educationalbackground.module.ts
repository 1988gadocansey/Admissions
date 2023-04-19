import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EducationalbackgroundRoutingModule } from './educationalbackground-routing.module';
import { EducationalbackgroundComponent } from './educationalbackground.component';
import { EducationalbackgroundpageComponent } from './pages/educationalbackgroundpage/educationalbackgroundpage.component';
import { EducationalbackgrounddetailsComponent } from './components/educationalbackgrounddetails/educationalbackgrounddetails.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgxLoadingModule } from 'ngx-loading';


@NgModule({
  declarations: [
    EducationalbackgroundComponent,
    EducationalbackgroundpageComponent,
    EducationalbackgrounddetailsComponent
    //EducationalbackgrounddetailsComponent
  ],
  imports: [
    CommonModule,
    EducationalbackgroundRoutingModule,
    ReactiveFormsModule,
    NgxLoadingModule,
    FormsModule
  ]
})
export class EducationalbackgroundModule { }
