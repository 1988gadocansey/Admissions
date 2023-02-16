import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/authorize.guard';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoComponent } from './todo/todo.component';
import { TokenComponent } from './token/token.component';
import {DashboardLayoutComponent} from "./dashboard/dashboard-layout/dashboard-layout.component";
import {PhotoComponent} from "./photo/photo.component";
import { PreloadAllModules } from '@angular/router';
import { TryService } from './services/try.service';
export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent ,
    resolve: {
      crisis: TryService  // for preloading component data. it block the page till everything finish loading
    }
  },
  { path: 'todo', component: TodoComponent, canActivate: [AuthorizeGuard] },


  {
    path: '',
    loadChildren: () => import('./shared/shared.module').then(m => m.SharedModule),

  },
  {
    path: 'dashboard',
    component: DashboardLayoutComponent,

    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  { path: 'stepone', loadChildren: () => import('./stepone/stepone.module').then(m => m.SteponeModule) },
  { path: 'resultupload', loadChildren: () => import('./resultupload/resultupload.module').then(m => m.ResultuploadModule) },


];
RouterModule.forRoot(routes, {preloadingStrategy: PreloadAllModules})

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})

export class AppRoutingModule {}
