import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UniversityattendedComponent } from './universityattended.component';
import { UniversityattendedpageComponent } from './pages/universityattendedpage/universityattendedpage.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: '',
    component: UniversityattendedComponent,
    children: [
      { path: '', redirectTo: 'universityattended', pathMatch: 'full' },
      { path: 'universityattended', component: UniversityattendedpageComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '/404' },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UniversityattendedRoutingModule { }
