import { NgModule } from '@angular/core';

import { CoreModule } from '../../core/core.module';

import { SharedModule } from '../../shared/shared.module';
import { LoginRoutingModule } from './login-routing.module';

import { LoginComponent } from './pages/login.component';


@NgModule({
  declarations: [
    LoginComponent,
  ],
  imports: [
    SharedModule,
    LoginRoutingModule,
    CoreModule,
  ],
})
export class LoginModule { }
