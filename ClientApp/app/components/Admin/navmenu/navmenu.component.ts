import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/AuthService';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css'],
    providers: [AuthService]
})
export class NavMenuComponent {

    constructor(private router: Router, private authSer: AuthService) {

    }

    logout() {

        this.authSer.logout();
    }
}
