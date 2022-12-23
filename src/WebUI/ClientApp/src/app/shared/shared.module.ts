import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppLayoutComponent } from './app-layout/app-layout.component';
import {RouterModule, Routes} from "@angular/router";
import {NavMenuComponent} from "./app-layout/nav-menu/nav-menu.component";
import {ApiAuthorizationModule} from "../../api-authorization/api-authorization.module";
import {SharedRoutingModule} from "./shared-routing.module";

import {HeaderComponent} from "./app-layout/header/header.component";
 const routes: Routes = [

];

@NgModule({
    declarations: [
        AppLayoutComponent,
        NavMenuComponent,
        HeaderComponent
    ],
    exports: [
        AppLayoutComponent
    ],
  imports: [
    CommonModule,
    RouterModule,
    ApiAuthorizationModule,
    SharedRoutingModule
  ]
})
export class SharedModule { }
