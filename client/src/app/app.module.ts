import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { OktaAuthModule } from '@okta/okta-angular';
import { CoreModule } from './core/core.module';
import { AuthRoutingModule } from './core/auth/auth-routing.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './layout/header/header.component';

import { DxMenuModule, DxNavBarModule } from 'devextreme-angular';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HomeComponent,
    HeaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthRoutingModule,
    CoreModule,
    OktaAuthModule.initAuth({
      issuer: 'https://dev-793026.okta.com/oauth2/default',
      redirectUri: 'http://localhost:4200/implicit/callback',
      clientId: '0oa26b0fwuZgO5hOB357',
    }),
    DxNavBarModule,
    DxMenuModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
