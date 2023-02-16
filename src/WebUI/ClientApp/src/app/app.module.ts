//import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from '@abacritt/angularx-social-login';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtModule } from '@auth0/angular-jwt';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './home/home.component';
import { ErrorHandlerService } from './core/services/error-handler.service';
import { SpinnerComponent } from './spinner/spinner.component';
import { LoadingInterceptor } from './core/interceptor/loading.interceptor';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';

@NgModule({
  declarations: [AppComponent, HomeComponent, SpinnerComponent],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, SharedModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
