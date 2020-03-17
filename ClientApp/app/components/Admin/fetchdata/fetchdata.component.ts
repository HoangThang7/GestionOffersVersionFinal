import { Component, Inject, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';
import { DatePipe, Location } from '@angular/common';
import { UserService } from '../../Services/UserService';
import { User } from '../../MoelNg/User';
import { CookieService } from 'ngx-cookie';
import { Router } from '@angular/router';


@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent implements OnInit{

    nameUser: string;
    tableUsers: any[];
    bool: boolean;
    error: Error;
    user: any;
    

    constructor(private userService: UserService, private router: Router, private cookie: CookieService) {
        this.tableUsers = new Array<any>();
        this.bool = false;
        this.nameUser = "";
    }

    ngOnInit() {
        
        this.userService.getListUser()
            .subscribe(resp => {
            this.tableUsers = resp
                console.log(this.tableUsers)
            }
          );
    }

    detailUser(user: User) {
        this.cookie.putObject("user", user);
        this.router.navigate(['/detail']);
    }


    removeUser(user: User) {
        if (window.confirm('Are you sure to delete this user?')) {
            this.userService.deleteUser(user.id)
                .subscribe(resp => {
                    this.bool = resp
                    var index = this.tableUsers.indexOf(user);
                    this.tableUsers.splice(index, 1);
                }, error => this.error = error
           )
        }
            
    }

     
}


