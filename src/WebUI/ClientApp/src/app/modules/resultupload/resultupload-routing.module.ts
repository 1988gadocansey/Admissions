import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResultuploadComponent } from './resultupload.component';
import { ResultuploaddetailsComponent } from './components/resultuploaddetails/resultuploaddetails.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { ResultuploadpageComponent } from './pages/resultuploadpage/resultuploadpage.component';

const routes: Routes = [
  {
    path: '',
    component: ResultuploadComponent,
    children: [
      { path: '', redirectTo: 'results', pathMatch: 'full' },
      { path: 'results', component: ResultuploadpageComponent, canActivate: [AuthorizeGuard] },
      { path: '**', redirectTo: '/404' },

    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ResultuploadRoutingModule { }
