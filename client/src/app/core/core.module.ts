import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthComponent } from './auth/auth.component';
import { OktaAuthService } from '@okta/okta-angular';
import { AuthService } from './auth/auth.service';
import { AuthRoutingModule } from './auth/auth-routing.module';





@NgModule({
  declarations: [
    AuthComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
  ],
  providers: [
    OktaAuthService,
    AuthService,
  ]
})
export class CoreModule { }
