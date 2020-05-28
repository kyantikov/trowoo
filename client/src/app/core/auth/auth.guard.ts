import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';

import { Observable } from 'rxjs';

import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private authService: AuthService) { }

  // @ts-ignore
  async canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Promise<Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree> {
    const isLoginPage = route.routeConfig.path === 'login';
    const isLoggedIn = await this.authService.getAuthState();
    if (isLoggedIn && isLoginPage) {
      this.router.navigate(['/']);
      return false;
    }
    if (!isLoggedIn && !isLoginPage) {
      this.router.navigate(['login']);
    }
    return isLoggedIn || isLoginPage;
  }

}
