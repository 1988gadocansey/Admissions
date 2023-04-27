import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrintviewComponent } from './printview.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';

const routes: Routes = [
  {
    path: 'proof',
    component: PrintviewComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../preview/preview.module').then((m) => m.PreviewModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrintRoutingModule { }
