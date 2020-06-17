import { ModuleWithProviders, NgModule } from '@angular/core';

import { OKTA_CONFIG, OktaAuthModule } from '@okta/okta-angular' ;

import { DxToolbarModule, DxDrawerModule, DxListModule, DxButtonModule } from 'devextreme-angular';

import appConfig from '../config/okta.config';
import { SharedModule } from '../shared/shared.module';
import { AuthService } from './auth/auth.service';

import { HeaderComponent } from './header/header.component';
import { SideNavComponent } from './side-nav/side-nav.component';


@NgModule({
  declarations: [
    HeaderComponent,
    SideNavComponent,
  ],
  imports: [
    SharedModule,
    OktaAuthModule,
    DxToolbarModule,
    DxDrawerModule,
    DxListModule,
    DxButtonModule,
  ],
  exports: [
    HeaderComponent,
    SideNavComponent,
  ],
  providers: [
    AuthService,
    { provide: OKTA_CONFIG, useValue: appConfig },
  ],
})
export class CoreModule { }
