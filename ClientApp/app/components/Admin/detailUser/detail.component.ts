import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { UserService } from '../../Services/UserService';
import { User } from '../../MoelNg/User';
import { Address } from '../../MoelNg/Address';
import { Router, ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie';
import { NgForm } from '@angular/forms';
import { Provider } from '../../MoelNg/Provider';

@Component({
    selector: 'detail',
    templateUrl: './detail.component.html'
})
export class UserComponent implements OnInit {

    user: any;
    data: any;
    error: Error;
  
    constructor(private userService: UserService, private cookie: CookieService) {
        this.user = new User();
        this.user.provider = new Provider();
        this.user.address = new Address();      
    }

    ngOnInit() {
        this.user = this.cookie.getObject("user");
        console.log(this.user);
        
    }

    onFormSubmit(form: NgForm) {

        this.userService.updateUser(this.user)
            .subscribe(resp => {
                this.data = resp
            }, error => this.error = error )
            
            
    }
}
