import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from './address.component';
import { AddresspageComponent } from './pages/addresspage/addresspage.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: '',
    component: AddressComponent,
    children: [
      { path: '', redirectTo: 'address', pathMatch: 'full' },
      { path: 'address', component: AddresspageComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '/404' },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AddressRoutingModule { }
