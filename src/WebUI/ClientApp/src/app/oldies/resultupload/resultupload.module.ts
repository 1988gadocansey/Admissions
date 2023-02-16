import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResultuploadRoutingModule } from './resultupload-routing.module';
import { ResultuploadComponent } from './resultupload.component';


@NgModule({
  declarations: [
    ResultuploadComponent
  ],
  imports: [
    CommonModule,
    ResultuploadRoutingModule
  ]
})
export class ResultuploadModule { }
