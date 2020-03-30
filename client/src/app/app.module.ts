import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { OKTA_CONFIG, OktaAuthModule} from '@okta/okta-angular';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './layout/home/home.component';
import { HeaderComponent } from './layout/header/header.component';

import { DxMenuModule, DxNavBarModule } from 'devextreme-angular';
import { Router } from '@angular/router';

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
    CoreModule,
    SharedModule,
    DxNavBarModule,
    DxMenuModule,
    OktaAuthModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
