import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/auth/auth.guard';

import { OktaCallbackComponent } from '@okta/okta-angular';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'positions',
    pathMatch: 'full',
  },
  {
    path: 'implicit/callback',
    component: OktaCallbackComponent },
  {
    path: 'login',
    canActivate: [AuthGuard],
    loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'positions',
    canActivate: [AuthGuard],
    loadChildren: () => import('./modules/all-positions-grid/all-positions-grid.module').then(m => m.AllPositionsGridModule)
  },
  {
    path: 'portfolios',
    canActivate: [AuthGuard],
    loadChildren: () => import('./modules/portfolios-manager/portfolios-manager.module').then(m => m.PortfoliosManagerModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
