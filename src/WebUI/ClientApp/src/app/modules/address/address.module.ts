import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddressRoutingModule } from './address-routing.module';
import { AddressComponent } from './address.component';
import { AddresspageComponent } from './pages/addresspage/addresspage.component';
import { AddressdetailsComponent } from './components/addressdetails/addressdetails.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgxLoadingModule } from 'ngx-loading';


@NgModule({
  declarations: [
    AddressComponent,
    AddresspageComponent,
    AddressdetailsComponent
  ],
  imports: [
    CommonModule,
    AddressRoutingModule,
    ReactiveFormsModule,
    NgxLoadingModule,
    FormsModule
  ]
})
export class AddressModule { }
