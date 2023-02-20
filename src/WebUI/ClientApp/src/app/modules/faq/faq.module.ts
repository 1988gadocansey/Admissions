import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FaqRoutingModule } from './faq-routing.module';
import { FaqdetailsComponent } from './components/faqdetails/faqdetails.component';
import { FaqpageComponent } from './pages/faqpage/faqpage.component';
import { FaqComponent } from './faq.component';


@NgModule({
  declarations: [
    FaqdetailsComponent,
    FaqpageComponent,
    FaqComponent
  ],
  imports: [
    CommonModule,
    FaqRoutingModule
  ]
})
export class FaqModule { }
