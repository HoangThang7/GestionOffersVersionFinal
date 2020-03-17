import { Component, ViewChild, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Bidder } from '../../MoelNg/Bidder';
import { Address } from '../../MoelNg/Address';
import { Plis } from '../../MoelNg/Plis';
import { Depouillement } from '../../MoelNg/Depouillement';
import { NgForm } from '@angular/forms';
import { PlisService } from '../../services/PlisService';
import { CookieService } from 'ngx-cookie';
import { Router } from '@angular/router';
import { DepouillementService } from '../../services/DepouillementService';

@Component({
    selector: 'depouillement',
    templateUrl: './depouillement.component.html'
})
export class DepouilleComponent implements OnInit {

    bidder: any;
    resultat: string[] = ["Accepted", "Refused"];
    noteFinance: number[] = [1, 2, 3, 4, 5];
    noteTechnic: number[] = [1, 2, 3, 4, 5]; 
    showDepouille: boolean;
    showForm: boolean;
    plis: any;
    user: any;
    depouillement: Depouillement;
    data: boolean;
    error: Error;
    public loading = false;

    constructor(private routage: Router, private cookie: CookieService, private depouillementService: DepouillementService) {
        this.plis = new Plis();
        this.plis.depouille = new Depouillement();
        this.depouillement = new Depouillement();
        this.showDepouille = false;
        this.showForm = true;
    }

    ngOnInit() {

        this.plis = this.cookie.getObject("plis");
        console.log(this.plis);
        this.user = this.cookie.getObject("CurrentUser");
        this.bidder = this.cookie.getObject("bidder");

        this.depouillementService.getDepouille(this.plis.id)
            .subscribe(b => {
                console.log(b);
                this.depouillement = b;
                if (this.depouillement.noteTechnical != 0) {
                    this.showForm = false;
                }
                console.log(this.depouillement);
            }, error => {
                this.error = error;
            })

        if (this.depouillement != null) {
            this.showDepouille = true;
        }
    }

    ShowBidder() {
        this.routage.navigate(['/detailbidder', this.bidder.id]);
    }

    SaveDepouille(form: NgForm) {

        this.depouillement.plisId = this.plis.id;
        this.loading = true;
        console.log(this.depouillement);
        this.depouillementService.addDepouillement(this.depouillement)
            .subscribe(d => {
                this.depouillement.id = d;
                this.showDepouille = true;
                this.showForm = false;
                this.loading = false;
            }, error => {
                this.error = error;
                this.loading = false;
            })
    }

    ModifyDepouille() {
        this.depouillementService.updateDepouille(this.depouillement)
            .subscribe(d => {
                this.data = d;
            }, error => {
                this.error = error;
            });
    }

    Contract() {     
        this.routage.navigate(['/contract', this.depouillement.id]);           
    }
}
