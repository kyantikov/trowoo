import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OKTA_CONFIG, OktaAuthModule } from '@okta/okta-angular' ;

import { DxToolbarModule } from 'devextreme-angular';

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
    DxToolbarModule,
    OktaAuthModule,
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
