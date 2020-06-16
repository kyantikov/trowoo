import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { DxResponsiveBoxModule } from 'devextreme-angular';

import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { LoginModule } from './modules/login/login.module';
import { AllPositionsGridModule } from './modules/all-positions-grid/all-positions-grid.module';

import { AppComponent } from './app.component';
import { AuthInterceptorService } from './core/auth/auth-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    SharedModule,
    LoginModule,
    AllPositionsGridModule,
    DxResponsiveBoxModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true},
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
