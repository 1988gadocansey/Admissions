import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AnnouncementsRoutingModule } from './announcements-routing.module';
import { AnnouncementPageComponent } from './page/announcement-page/announcement-page.component';

import { AnouncementdetailsComponent } from './components/anouncementdetails/anouncementdetails.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AnnouncementsComponent } from './announcements.component';


@NgModule({
  declarations: [
    AnnouncementPageComponent,
    AnouncementdetailsComponent,
    AnnouncementsComponent
  ],
  imports: [
    CommonModule,
    AnnouncementsRoutingModule,
    SharedModule
  ]
})
export class AnnouncementsModule { }
