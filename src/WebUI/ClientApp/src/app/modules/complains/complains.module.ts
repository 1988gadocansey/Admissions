import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ComplainsRoutingModule } from './complains-routing.module';
import { ComplainsComponent } from './complains.component';
import { ComplainsdetailsComponent } from './components/complainsdetails.component';
import { ComplainspageComponent } from './pages/complainspage.component';


@NgModule({
  declarations: [
    ComplainsComponent,
    ComplainsdetailsComponent,
    ComplainspageComponent
  ],
  imports: [
    CommonModule,
    ComplainsRoutingModule
  ]
})
export class ComplainsModule { }
