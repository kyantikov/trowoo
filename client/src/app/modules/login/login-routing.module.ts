import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { OktaCallbackComponent } from '@okta/okta-angular';

import { LoginComponent } from './pages/login.component';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'implicit/callback', component: OktaCallbackComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
