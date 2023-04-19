import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EducationalbackgroundComponent } from './educationalbackground.component';
import { EducationalbackgroundpageComponent } from './pages/educationalbackgroundpage/educationalbackgroundpage.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: '',
    component: EducationalbackgroundComponent,
    children: [
      { path: '', redirectTo: 'educationalbackground', pathMatch: 'full' },
      { path: 'educationalbackground', component: EducationalbackgroundpageComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '/404' },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EducationalbackgroundRoutingModule { }
