import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PreviewRoutingModule } from './preview-routing.module';
import { PreviewComponent } from './preview.component';
import { HttpClientModule } from '@angular/common/http';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { NgApexchartsModule } from 'ng-apexcharts';
import { PreviewpageComponent } from './pages/previewpage/previewpage.component';
import { PreviewdetailsComponent } from './components/previewdetails/previewdetails.component';
import { NgxLoadingModule } from 'ngx-loading';
import { ProgrammePipePipe } from './components/programme-pipe.pipe';


@NgModule({
  declarations: [
    PreviewComponent,
    PreviewpageComponent,
    PreviewdetailsComponent,
    ProgrammePipePipe

  ],
  imports: [
    CommonModule,
    PreviewRoutingModule,
    HttpClientModule,
    NgApexchartsModule,
    NgxLoadingModule,
    AngularSvgIconModule.forRoot(),
  ]
})
export class PreviewModule { }
