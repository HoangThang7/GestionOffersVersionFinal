import { Component, OnInit} from '@angular/core';
import { Offer } from '../../MoelNg/Offer';
import { Categorie } from '../../MoelNg/Categorie';
import { OfferService } from '../../services/OfferService';
import { Direction } from '../../MoelNg/Direction';
import { CookieService } from 'ngx-cookie';
import { Router, ActivatedRoute } from '@angular/router';
import { FileService } from '../../services/FileServcie';




@Component({
    selector: 'offerDetail',
    templateUrl: './offerDetail.component.html'
})
export class OfferDetailComponent implements OnInit{

    
    offerDetail: any;
    offerId: number = 0;
    data: any;
    files: any;
    error: Error;
 

    constructor(private fileService: FileService, private offerService: OfferService, private cookie: CookieService, private routage: Router, private activRoute: ActivatedRoute) {
        this.offerDetail = new Offer();
        this.offerDetail.categorie = new Categorie();
        this.offerDetail.direction = new Direction();

    }


    ngOnInit() {
        this.offerId = this.activRoute.snapshot.params['id'];

        this.offerService.getOffer(this.offerId)
            .subscribe(o => {
                this.offerDetail = o;
                console.log(this.offerDetail);               
            }, error => {
                this.error = error;
            });

    }

   

}