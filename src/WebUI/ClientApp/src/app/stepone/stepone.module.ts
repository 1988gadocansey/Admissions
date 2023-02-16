import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SteponeRoutingModule } from './stepone-routing.module';
import { SteponeComponent } from './stepone.component';


@NgModule({
  declarations: [
    SteponeComponent
  ],
  imports: [
    CommonModule,
    SteponeRoutingModule
  ]
})
export class SteponeModule { }
