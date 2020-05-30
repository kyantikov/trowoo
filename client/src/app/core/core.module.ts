import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OKTA_CONFIG, OktaAuthModule } from '@okta/okta-angular' ;

import { DxToolbarModule, DxDrawerModule, DxListModule } from 'devextreme-angular';

import appConfig from '../config/okta.config';
import { AuthService } from './auth/auth.service';
import { HeaderComponent } from './header/header.component';
import { SideNavComponent } from './side-nav/side-nav.component';


@NgModule({
  declarations: [
    HeaderComponent,
    SideNavComponent,
  ],
  imports: [
    CommonModule,
    OktaAuthModule,
    DxToolbarModule,
    DxDrawerModule,
    DxListModule,
  ],
  exports: [
    HeaderComponent,
    SideNavComponent,
  ],
  providers: [
    AuthService,
  ],
})
export class CoreModule {
  static forChild(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        { provide: OKTA_CONFIG, useValue: appConfig },
      ],
    };
  }
}
