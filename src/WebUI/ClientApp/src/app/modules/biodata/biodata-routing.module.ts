import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { BiodataComponent } from './biodata.component';
import { BiodatapageComponent } from './pages/biodatapage.component';

const routes: Routes = [
  {
    path: '',
    component: BiodataComponent,
    children: [
      { path: '', redirectTo: 'biodata', pathMatch: 'full' },
      { path: 'biodata', component: BiodatapageComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '/404' },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BiodataRoutingModule { }
