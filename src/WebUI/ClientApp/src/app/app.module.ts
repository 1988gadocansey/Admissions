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
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TokenComponent } from './token/token.component';
import { TodoComponent } from './todo/todo.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { NgxLoadingModule, ngxLoadingAnimationTypes } from 'ngx-loading';
import { StoreModule } from '@ngrx/store';
import { counterReducer } from './store/reducers/user.reducer';
import { TryStoreComponent } from './try-store/try-store.component';

@NgModule({
  declarations: [AppComponent, SpinnerComponent, FetchDataComponent, TokenComponent, TodoComponent, TryStoreComponent],
  imports: [BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, SharedModule, CommonModule, ApiAuthorizationModule, AppRoutingModule,
    BrowserAnimationsModule,
  NgxLoadingModule.forRoot({
    animationType: ngxLoadingAnimationTypes.circle,
    backdropBackgroundColour: 'rgba(192,192,192,0.4)',
    backdropBorderRadius: '4px',
    primaryColour: '#64b2cd',
    secondaryColour: '#ffffff',
    tertiaryColour: '#ffffff'
  }),
  StoreModule.forRoot({ count: counterReducer }),


  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
