import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrintRoutingModule } from './print-routing.module';
import { PrintviewComponent } from './printview.component';


@NgModule({
  declarations: [
    PrintviewComponent
  ],
  imports: [
    CommonModule,
    PrintRoutingModule
  ]
})
export class PrintModule { }
