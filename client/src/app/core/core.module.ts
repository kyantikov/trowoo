import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OKTA_CONFIG, OktaAuthService } from '@okta/okta-angular' ;

import { AuthComponent } from './components/auth/auth.component';
import { AuthService } from './services/auth.service';
import { CoreRoutingModule } from './core-routing.module';
import appConfig from '../app.config';


const oktaConfig = Object.assign({
  onAuthRequired: ({oktaAuth, router}) => {
    // Redirect the user to your custom login page
    router.navigate(['/login']);
  }
}, appConfig);

@NgModule({
  declarations: [
    AuthComponent,
  ],
  imports: [
    CommonModule,
    CoreRoutingModule,
  ],
  providers: [
    OktaAuthService,
    AuthService,
    {provide: OKTA_CONFIG, useValue: oktaConfig},
  ]
})
export class CoreModule { }
