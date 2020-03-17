import { Component, ViewChild, OnInit } from '@angular/core';
import { Offer } from '../../MoelNg/Offer';
import { Categorie } from '../../MoelNg/Categorie';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http';
import { OfferService } from '../../services/OfferService';
import { Router } from '@angular/router';
import { Direction } from '../../MoelNg/Direction';
import { CookieService } from 'ngx-cookie';



@Component({
    selector: 'fetchoffer',
    templateUrl: './fetchoffer.component.html'
})
export class FetchOfferComponent implements OnInit {

    offers: any[];
    bool: boolean;
    error: Error;
    offerSearch: any[];
    offer: any;
    show: boolean;
    codeOffer: string;
    user: any;
    page: number = 1;

    constructor(private offerService: OfferService, private router: Router, private cookie: CookieService) {
        this.offers = new Array<any>();
        this.offerSearch = new Array<any>();
        this.bool = false;
        this.show = false;
        this.codeOffer = "";
    }

    ngOnInit() {

        this.user = this.cookie.getObject("CurrentUser");
        console.log(this.user);

        this.offerService.getOffers()
            .subscribe(resp => {
                this.offers = resp
                console.log(this.offers)
            }
         );
    }

    RemoveOffer(offer: Offer) {

        if (window.confirm('Are you sure to delete this Offer?')) {
            this.offerService.deleteOffer(offer.id)
                .subscribe(resp => {
                    this.bool = resp
                    if (this.bool == true) {
                        var index = this.offers.indexOf(offer);
                        this.offers.splice(index, 1);
                    }
                }, error => this.error = error
                )

        }
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

    
    DetailOffer(offer: Offer) {

        console.log(offer.id);
        this.cookie.putObject("offer", offer);
        this.router.navigate(['/detailOffer']);

    }
}