import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BiodataRoutingModule } from './biodata-routing.module';
import { BiodataComponent } from './biodata.component';
import { BiodatapageComponent } from './pages/biodatapage.component';
import { BiodatadetailsComponent } from './components/biodatadetails.component';
import {ReactiveFormsModule} from "@angular/forms";


@NgModule({
  declarations: [
    BiodataComponent,
    BiodatapageComponent,
    BiodatadetailsComponent
  ],
    imports: [
        CommonModule,
        BiodataRoutingModule,
        ReactiveFormsModule
    ]
})
export class BiodataModule { }
