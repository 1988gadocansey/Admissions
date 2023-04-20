import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UniversityattendedRoutingModule } from './universityattended-routing.module';
import { UniversityattendedComponent } from './universityattended.component';
import { UniversityattendeddetailsComponent } from './component/universityattendeddetails/universityattendeddetails.component';
import { UniversityattendedpageComponent } from './pages/universityattendedpage/universityattendedpage.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgxLoadingModule } from 'ngx-loading';


@NgModule({
  declarations: [
    UniversityattendedComponent,
    UniversityattendeddetailsComponent,
    UniversityattendedpageComponent
  ],
  imports: [
    CommonModule,
    UniversityattendedRoutingModule,
    ReactiveFormsModule,
    NgxLoadingModule,
    FormsModule
  ]
})
export class UniversityattendedModule { }
