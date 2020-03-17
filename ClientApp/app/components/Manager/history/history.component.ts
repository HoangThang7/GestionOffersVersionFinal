import { Component, ChangeDetectionStrategy } from '@angular/core';
import { CookieService } from 'ngx-cookie';
import { OfferService } from '../../services/OfferService';
import { HistoryService } from '../../services/HistoryService';
import { Router } from '@angular/router';
import { Offer } from '../../MoelNg/Offer';


@Component({
    selector: 'history',    
    templateUrl: './history.component.html',  
})
export class HistoryComponent {

    offers: any[];
    bool: boolean;
    error: Error;
    offerSearch: any[];
    offerDetail: any;
    show: boolean;
    codeOffer: string;
    user: any;
    page: number = 1;

    constructor(private historyService: HistoryService, private offerService: OfferService, private router: Router, private cookie: CookieService) {
        this.offers = new Array<any>();
        this.offerSearch = new Array<any>();
        this.bool = false;
        this.show = false;
        this.codeOffer = "";
        this.offerDetail = new Offer();
        
    }

    ngOnInit() {

        this.user = this.cookie.getObject("CurrentUser");
        console.log(this.user);

        this.offerService.getOffers()
            .subscribe(resp => {
                this.offers = resp;
                console.log(this.offers);
            });
    }

    SortAscend() {
        if (this.show == false) {
            this.offers.sort(function (a, b) {
                return new Date(a.dateLimit).getTime() - new Date(b.dateLimit).getTime();
            });
        } else {
            this.offerSearch.sort(function (a, b) {
                return new Date(a.dateLimit).getTime() - new Date(b.dateLimit).getTime();
            });
        }
    }

    SortDescend() {
        if (this.show == false) {
            this.offers.sort(function (a, b) {
                return new Date(b.dateLimit).getTime() - new Date(a.dateLimit).getTime();
            });
        } else {
            this.offerSearch.sort(function (a, b) {
                return new Date(b.dateLimit).getTime() - new Date(a.dateLimit).getTime();
            });
        }
    }

    pageChanged(event: any) {
        this.page = event;
    }

    ShowOffers() {
        this.show = false;
    }

    UserSearch() {
        this.offerSearch = [];

        for (var i = 0; i < this.offers.length; i++) {
            if (this.offers[i].manager == this.user.mail) {
                this.offerSearch.push(this.offers[i]);
            }
        }
        console.log(this.offerSearch);
        this.show = true;
    }

    DetailOffer(off: Offer) {
        console.log(off.id);
        this.historyService.getOffer(off.id)
            .subscribe(resp => {
                this.offerDetail = resp;
                console.log(this.offerDetail);
                this.cookie.putObject("offer", this.offerDetail);
                this.router.navigate(['/detailOffer']);
            });
        
       

    }
    
}