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
    selector: 'offerlist',
    templateUrl: './offerlist.component.html'
})
export class OfferListComponent implements OnInit {

    offers: any[];
    offerToDetail: any;
    show: boolean;
    bool: boolean;
    error: Error;
    listOffer: any[];
    codeOffer: string = "";

    constructor(private offerService: OfferService, private router: Router, private cookie: CookieService) {
        this.offers = new Array<any>();
        this.bool = false;
        this.show = false;
        this.offerToDetail = null;
        this.listOffer = new Array<any>();
    }

    ngOnInit() {

        this.offerService.getOffers()
            .subscribe(resp => {
                this.listOffer = resp
                if (this.listOffer.length > 0) {
                    for (var i = 0; i < this.listOffer.length; i++) {
                        if (this.listOffer[i].publish == true && this.listOffer[i].etat == "Ouvert") {
                            this.offers.push(this.listOffer[i]);
                        }
                    }
                }
                console.log(this.offers)
            }
         );
    }


    DetailOffer(off: Offer) {
        this.router.navigate(['/offerDetail' , off.id]);
    }
}