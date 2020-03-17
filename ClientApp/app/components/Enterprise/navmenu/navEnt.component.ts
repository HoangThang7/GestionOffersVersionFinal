import { Component } from '@angular/core';
import { AuthService } from '../../services/AuthService';
import { Router } from '@angular/router';

@Component({
    selector: 'navEnt-menu',
    templateUrl: './navEnt.component.html',
    styleUrls: ['./navEnt.component.css'],
    providers: [AuthService]
})
export class NavEntComponent {

    constructor(private router: Router, private authSer: AuthService) {

    }

    logout() {

        this.authSer.logout();
    }
}

