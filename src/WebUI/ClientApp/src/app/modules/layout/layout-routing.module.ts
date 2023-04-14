import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { AuthorizeGuard } from "../../../api-authorization/authorize.guard";
import { PassportpicComponent } from '../passportpic/passportpic.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../dashboard/dashboard.module').then((m) => m.DashboardModule),
  },
  {
    path: 'academics',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../academics/academics.module').then((m) => m.AcademicsModule),
  },
  {
    path: 'announcements',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../announcements/announcements.module').then((m) => m.AnnouncementsModule),
  },
  {
    path: 'faq',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../faq/faq.module').then((m) => m.FaqModule),
  },
  {
    path: 'forms',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../biodata/biodata.module').then((m) => m.BiodataModule),
  },
  {
    path: 'steptwo',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../academics/academics.module').then((m) => m.AcademicsModule),
  },
  {
    path: 'stepthree',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../resultupload/resultupload.module').then((m) => m.ResultuploadModule),
  },
  {
    path: 'proof',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../preview/preview.module').then((m) => m.PreviewModule),
  },
  {
    path: 'issues',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../complains/complains.module').then((m) => m.ComplainsModule),
  },
  {
    path: 'changes',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../changeform/changeform.module').then((m) => m.ChangeformModule),
  },
  {
    path: 'upload',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../passportpic/passportpic.module').then((m) => m.PassportpicModule),
  },
  {
    path: 'welcome',
    component: LayoutComponent,
    canActivate: [AuthorizeGuard],
    loadChildren: () => import('../welcome/welcome.module').then((m) => m.WelcomeModule),
  },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: '/404' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LayoutRoutingModule { }
