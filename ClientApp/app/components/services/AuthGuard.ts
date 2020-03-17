import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthGuard implements CanActivate {


    isLoggedIn: boolean = false;

    constructor(private router: Router) { }

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

        var user = localStorage.getItem('User');
        if (user) {
            this.isLoggedIn = true;
        }


        if (this.isLoggedIn == false) {
            // Si pas d'utilisateur connecté : redirection vers la page de login
            console.log('Vous n\'êtes pas connectés');
            this.router.navigate(['/home']);
        }
        return this.isLoggedIn;
    }
  }
    
