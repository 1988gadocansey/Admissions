import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultuploadComponent } from './resultupload.component';

const routes: Routes = [{ path: '', component: ResultuploadComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResultuploadRoutingModule { }
