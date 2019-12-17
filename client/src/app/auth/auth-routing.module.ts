import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from "./auth.component";
import { OktaCallbackComponent } from "@okta/okta-angular";


const routes: Routes = [
  {path: 'login', component: AuthComponent},
  {path: 'implicit/callback', component: OktaCallbackComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
