import { Component, ViewChild, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { FileService } from '../../services/FileServcie';
import { CommissionService } from '../../services/CommissionService';
import { BidderService } from '../../services/BidderService';
import { Bidder } from '../../MoelNg/Bidder';
import { Address } from '../../MoelNg/Address';
import { Offer } from '../../MoelNg/Offer';
import { Plis } from '../../MoelNg/Plis';
import { Depouillement } from '../../MoelNg/Depouillement';
import { PlisService } from '../../services/PlisService';
import { CookieService } from 'ngx-cookie';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm, ReactiveFormsModule, FormGroup, FormControl, ValidationErrors, Validators } from '@angular/forms';

@Component({
    selector: 'detailBidder',
    templateUrl: './detailBid.component.html'
})
export class DetailBidderComponent implements OnInit{

    detail: any;
    offer: any;
    showPlis: boolean = false;
    data: any;
    plis: Plis;
    user: any;
    error: Error;
    update: string = "";
    typeDep: string[] = ["Dossier", "Mail", "Fax"];
    plisForm: FormGroup;

    constructor(private bidderService: BidderService, private plisService: PlisService, private cookie: CookieService, private routage: Router, private route: ActivatedRoute) {
        this.detail = new Bidder();
        this.detail.address = new Address();
        this.detail.plis = new Array<Plis>();
        this.plis = new Plis();
        this.plis.depouille = new Depouillement();
        this.plis.depouille = new Depouillement();     

        this.plisForm = new FormGroup({
            'code': new FormControl(this.plis.code, [Validators.required]),
            'libelle': new FormControl(this.plis.libelle, [Validators.required]),
            'dateDepot': new FormControl(this.plis.dateDepot, [Validators.required]),
            'typeDepot': new FormControl(this.plis.typeDepot, [Validators.required]),
        })  
    }

    get code() { return this.plisForm.get('code'); }
    get libelle() { return this.plisForm.get('libelle'); }
    get dateDepot() { return this.plisForm.get('dateDepot'); }
    get typeDepot() { return this.plisForm.get('typeDepot'); }

    ngOnInit() {

        let bidId = this.route.snapshot.params['id'];
        this.offer = this.cookie.getObject("offer");
        console.log(this.offer);
        console.log(bidId);
        
        this.bidderService.getBidder(bidId)
            .subscribe(b => {
                this.detail = b;
                console.log(this.detail);
                if (this.detail.plis != null) {
                    for (var i = 0; i < this.detail.plis.length; i++) {
                        if (this.detail.plis[i].offerId == this.offer.id) {
                            this.plis = this.detail.plis[i];
                            console.log(this.plis);
                            if (this.plis.code != null) {
                                this.showPlis = true;
                            }
                        }
                    }
                }
            }, error => {
                this.error = error;
            });

        
        console.log(this.detail);
        this.user = this.cookie.getObject("CurrentUser");
        
    }

    ShowOffer() {
        this.routage.navigate(['/detailOffer']);
    }

    ModifyBidder(form: NgForm) {

        this.bidderService.updateBid(this.detail)
            .subscribe(b => {
                this.data = b;
            })
    }

    Depouille() {
        
        this.cookie.putObject("plis", this.plis);
        this.cookie.putObject("bidder", this.detail);
        this.routage.navigate(['/depouille']);
    }

    SavePlis() {

        this.plis.bidderId = this.detail.id;
        this.plis.offerId = this.offer.id;
      
        console.log(this.plis);
        this.plisService.postPlis(this.plis)
            .subscribe(p => {
                this.plis.id = p;
                this.showPlis = true;
            })
    }

    ModifyPlis(fo: NgForm) {
        console.log(this.plis);
        this.plisService.updatePlis(this.plis)
            .subscribe(p => {
                this.data = p;
                if (this.data == true) {
                    this.update = "Update success";
                }
            }, error => this.error = error
        )
    }
  }

  
