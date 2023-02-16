import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../../api-authorization/authorize.guard';
import {PhotoComponent} from "../photo/photo.component";


export const routes: Routes = [
  { path: 'picture', component: PhotoComponent,  canActivate: [AuthorizeGuard]  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SharedRoutingModule {}
