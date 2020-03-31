import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreModule } from '../../core/core.module';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './pages/login.component';


@NgModule({
  declarations: [
    LoginComponent,
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    CoreModule.forChild(),
  ],
  providers: [],
})
export class LoginModule { }
