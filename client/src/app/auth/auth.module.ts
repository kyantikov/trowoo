import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthComponent } from './auth.component';

import { OktaAuthService } from "@okta/okta-angular";
import {AuthRoutingModule} from "./auth-routing.module";


@NgModule({
  declarations: [AuthComponent],
  imports: [
    CommonModule
  ],
  exports: [
    AuthComponent,
    AuthRoutingModule
  ],
  providers: [OktaAuthService]
})
export class AuthModule { }
