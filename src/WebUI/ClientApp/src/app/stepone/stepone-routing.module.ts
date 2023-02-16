import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SteponeComponent } from './stepone.component';

const routes: Routes = [{ path: '', component: SteponeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SteponeRoutingModule { }
