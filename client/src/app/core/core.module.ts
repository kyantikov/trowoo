import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OKTA_CONFIG, OktaAuthModule, OktaAuthService } from '@okta/okta-angular' ;

import { DxMenuModule, DxNavBarModule } from 'devextreme-angular';

import appConfig from '../config/okta.config';
import { HeaderComponent } from './header/header.component';

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
})
export class CoreModule {
  static forChild(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        {provide: OKTA_CONFIG, useValue: oktaConfig}
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
