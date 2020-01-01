import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { OktaAuthModule } from "@okta/okta-angular";
import { AuthModule } from "./auth/auth.module";

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthRoutingModule } from "./auth/auth-routing.module";

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthRoutingModule,
    AuthModule,
    OktaAuthModule.initAuth({
      issuer: 'https://dev-793026.okta.com/oauth2/default',
      redirectUri: 'http://localhost:4200/implicit/callback',
      clientId: '0oa26b0fwuZgO5hOB357',
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
