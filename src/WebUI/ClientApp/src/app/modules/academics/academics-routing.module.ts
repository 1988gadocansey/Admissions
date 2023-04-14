import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AcademicsComponent } from './academics.component';
import { AcademicdetailsComponent } from './pages/academicdetails/academicdetails.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: '',
    component: AcademicsComponent,
    children: [
      { path: '', redirectTo: 'academics', pathMatch: 'full' },
      { path: 'academics', component: AcademicdetailsComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '/404' },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AcademicsRoutingModule { }
