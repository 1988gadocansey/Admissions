import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
//import { AuthGuard } from './core/guards/auth.guard';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { TodoComponent } from './todo/todo.component';
import { TokenComponent } from './token/token.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'token', component: TokenComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'todo', component: TodoComponent },
  // { path: 'biodata', component: BiodataComponent, canActivate: [AuthGuard] },
  { path: '404', component: NotFoundComponent },

  {
    path: '',
    loadChildren: () => import('./modules/layout/layout.module').then((m) => m.LayoutModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then((m) => m.AuthModule),
  },
  //{ path: '**', redirectTo: 'error/404' },
  { path: '**', redirectTo: '/404', pathMatch: 'full' },

];
RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
