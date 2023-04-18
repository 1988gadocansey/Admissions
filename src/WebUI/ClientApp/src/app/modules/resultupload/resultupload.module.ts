import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResultuploadRoutingModule } from './resultupload-routing.module';
import { ResultuploaddetailsComponent } from './components/resultuploaddetails/resultuploaddetails.component';
import { ResultuploadpageComponent } from './pages/resultuploadpage/resultuploadpage.component';
import { ResultuploadComponent } from './resultupload.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgxLoadingModule } from 'ngx-loading';

@NgModule({
  declarations: [
    ResultuploaddetailsComponent,
    ResultuploadpageComponent,
    ResultuploadComponent
  ],
  imports: [
    CommonModule,
    ResultuploadRoutingModule,
    ReactiveFormsModule,
    NgxLoadingModule,
    FormsModule
  ]
})
export class ResultuploadModule { }
