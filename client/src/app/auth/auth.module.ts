import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthComponent } from './auth.component';

import { OktaAuthService } from "@okta/okta-angular";
import { AuthRoutingModule } from "./auth-routing.module";
import { AuthService } from "./auth.service";


@NgModule({
  declarations: [AuthComponent],
  imports: [
    CommonModule
  ],
  exports: [
    AuthRoutingModule
  ],
  providers: [
    OktaAuthService,
    AuthService,
  ]
})
export class AuthModule { }
