import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AcademicsRoutingModule } from './academics-routing.module';
import { AcademicsComponent } from './academics.component';
import { AcademicdetailsComponent } from './pages/academicdetails/academicdetails.component';
import { AcademiccomponentComponent } from './components/academiccomponent/academiccomponent.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxLoadingModule } from 'ngx-loading';


@NgModule({
  declarations: [
    AcademicsComponent,
    AcademicdetailsComponent,
    AcademiccomponentComponent
  ],
  imports: [
    CommonModule,
    AcademicsRoutingModule,
    ReactiveFormsModule,
    NgxLoadingModule,
    FormsModule
  ]
})
export class AcademicsModule { }
