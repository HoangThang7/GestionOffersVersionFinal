import { Component, OnInit} from '@angular/core';
import { CookieService } from 'ngx-cookie';
import { User } from '../../MoelNg/User';
import { DatePipe } from '@angular/common';
import { UserService } from '../../Services/UserService';
import { Address } from '../../MoelNg/Address';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';
import { Provider } from '../../MoelNg/Provider';


@Component({
    selector: 'profil',
    templateUrl: './profil.component.html'
})
export class ProfilComponent implements OnInit {

    CurrentUser: any;
    data: any;
 

    constructor(private cookiService: CookieService, private userService: UserService) {
        
      
    }


    ngOnInit() {
        this.CurrentUser = this.cookiService.getObject('CurrentUser');

        console.log(this.CurrentUser);
    }

    onFormSubmit(form: NgForm) {
      

        this.userService.updateUser(this.CurrentUser)
            .subscribe(resp => {
                this.data = resp  
            })
    }

    
}
