import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OKTA_CONFIG, OktaAuthModule, OktaAuthService } from '@okta/okta-angular' ;

import { DxMenuModule, DxNavBarModule } from 'devextreme-angular';

import { AuthService } from './auth/auth.service';
import { HeaderComponent } from './header/header.component';
import appConfig from '../config/okta.config';

const oktaConfig = Object.assign({
  onAuthRequired: ({oktaAuth, router}) => {
    // Redirect the user to your custom login page
    router.navigate(['/login']);
  }
}, appConfig);

@NgModule({
  declarations: [
    HeaderComponent,
  ],
  imports: [
    CommonModule,
    DxNavBarModule,
    DxMenuModule,
    OktaAuthModule,
  ],
  exports: [
    HeaderComponent,
  ],
  providers: [],
})
export class CoreModule {
  static forAuth(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        OktaAuthService,
        AuthService,
        {provide: OKTA_CONFIG, useValue: oktaConfig},
      ]
    };
  }

  static forChild(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [

      ],
    };
  }

  static forRoot(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: []
    };
  }

}
