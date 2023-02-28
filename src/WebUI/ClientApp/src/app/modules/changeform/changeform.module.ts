import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ChangeformRoutingModule } from './changeform-routing.module';
import { ChangeformpageComponent } from './pages/changeformpage.component';
import { ChangeformdetailsComponent } from './components/changeformdetails.component';
import { ChangeformComponent } from './changeform.component';


@NgModule({
  declarations: [
    ChangeformpageComponent,
    ChangeformdetailsComponent,
    ChangeformComponent
  ],
  imports: [
    CommonModule,
    ChangeformRoutingModule
  ]
})
export class ChangeformModule { }
