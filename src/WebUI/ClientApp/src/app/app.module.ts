import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './bootstrap-apps/nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './bootstrap-apps/counter/counter.component';
import { FetchDataComponent } from './bootstrap-apps/fetch-data/fetch-data.component';
import { TodoComponent } from './bootstrap-apps/todo/todo.component';
import { TokenComponent } from './bootstrap-apps/token/token.component';
//import { AppRoutingModule } from './app-routing.module';
//import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
//import { HomeComponent } from './home/home.component';
import { ErrorHandlerService } from './core/services/error-handler.service';
import { SpinnerComponent } from './spinner/spinner.component';
import { LoadingInterceptor } from './core/interceptor/loading.interceptor';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    //FetchDataComponent,
    //TodoComponent,
    // TokenComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AppRoutingModule, SharedModule,
    ModalModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
