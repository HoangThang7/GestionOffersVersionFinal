import { Component, ViewChild, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { Bidder } from '../../MoelNg/Bidder';
import { Address } from '../../MoelNg/Address';
import { Plis } from '../../MoelNg/Plis';
import { Depouillement } from '../../MoelNg/Depouillement';
import { NgForm } from '@angular/forms';
import { PlisService } from '../../services/PlisService';
import { CookieService } from 'ngx-cookie';
import { Router, ActivatedRoute } from '@angular/router';
import { ContractService } from '../../services/ContractService';
import { Contract } from '../../MoelNg/Contract';
import { DepouillementService } from '../../services/DepouillementService';

@Component({
    selector: 'contract',
    templateUrl: './contract.component.html'
})
export class ContractComponent implements OnInit {

    showContract: boolean = false;
    depouille: any;
    user: any;
    data: boolean;
    contract: Contract;
    error: Error;
    loading: boolean = false;


    constructor(private routage: Router, private cookie: CookieService, private contractService: ContractService, private activeroute: ActivatedRoute, private depouilService: DepouillementService) {
        this.depouille = new Depouillement();
        this.contract = new Contract();
        
    }

    ngOnInit() {

        let bidId = this.activeroute.snapshot.params['id'];
        console.log(bidId);
        this.user = this.cookie.getObject("CurrentUser");


        this.depouilService.getDepouille(bidId)
            .subscribe(d => {
                this.depouille = d;
                console.log(this.depouille);
                if (this.depouille.contract != null) {
                    this.contract = this.depouille.contract;
                    this.showContract = true;
                }
            }, error => {
                this.error = error;               
            })          
    }

   
    ShowBidder() {

        this.routage.navigate(['/detailbidder', this.depouille.id]);
    }

    SaveContract(form: NgForm) {

        this.contract.depouilleId = this.depouille.id;
        this.loading = true;
        console.log(this.contract);
        this.contractService.addContract(this.contract)
            .subscribe(c => {
                this.contract.id = c;
                this.loading = false;
                this.showContract = true;

            }, error => {
                this.error = error
            });
    }

    Remove() {

        this.contractService.deleteContract(this.contract.id)
            .subscribe(d => {
                this.data = d;
                if (this.data == true) {
                    this.showContract = false;
                }
            }, error => this.error = error
        )
    }

    ModifyContract() {

        this.contractService.updateContract(this.contract)
            .subscribe(d => {
                this.data = d;
            }, error => this.error = error
         )
    }
}
