import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PassportpicRoutingModule } from './passport.routing.module';
import { UploadpicComponent } from './components/uploadpic/uploadpic.component';
import { UploadpageComponent } from './pages/uploadpage/uploadpage.component';
import { PassportpicComponent } from './passportpic.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [
    PassportpicComponent,
    UploadpicComponent,

    UploadpageComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PassportpicRoutingModule,
    HttpClientModule,

    FormsModule,

    ReactiveFormsModule
  ]
})
export class PassportpicModule { }
