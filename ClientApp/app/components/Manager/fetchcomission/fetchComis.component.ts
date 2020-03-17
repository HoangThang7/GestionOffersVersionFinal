import { Component, ViewChild, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';
import { OfferService } from '../../services/OfferService';
import { Router } from '@angular/router';
import { Commission } from '../../MoelNg/Commission';
import { User } from '../../MoelNg/User';
import { CookieService } from 'ngx-cookie';
import { CommissionService } from '../../services/CommissionService';


@Component({
    selector: 'fetchcomis',
    templateUrl: './fetchComis.component.html'
})
export class FetchComisComponent implements OnInit {


    listCommis: any[]
    comisSearch: any
    show: boolean
    bool: boolean
    error: Error
    commisDetail: Commission
    user: any;
    codeCommis: string
    page: number = 1;

    constructor(private commissionServcie: CommissionService, private cookie: CookieService) {
        this.bool = false;
        this.show = false;
        this.listCommis = new Array<any>();
        this.comisSearch = new Array<any>();
        this.commisDetail = new Commission();
        this.commisDetail.members = new Array<User>();
        this.codeCommis = "";
    }

    ngOnInit() {
        this.user = this.cookie.getObject("CurrentUser");

        this.commissionServcie.getCommission()
            .subscribe(x => {
                this.listCommis = x;
                console.log(this.listCommis);
            })
    }
    
    DetailCommis(comis: Commission) {
        this.commisDetail = comis;
    }

   
    RemoveCommis(comis: Commission) {
        console.log(comis);
        if (window.confirm('Are you sure to delete this commission?')) {
            this.commissionServcie.deleteCommis(comis.id)
                .subscribe(resp => {
                    this.bool = resp
                    if (this.bool == true) {
                        var index = this.listCommis.indexOf(comis);
                        this.listCommis.splice(index, 1);
                    }
                }, error => this.error = error
           )
        }
    }

    pageChanged(event: any) {
        this.page = event;
    }
}