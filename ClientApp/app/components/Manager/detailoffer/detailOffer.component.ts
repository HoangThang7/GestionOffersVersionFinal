import { Component, ViewChild, OnInit, Input, Output, EventEmitter, ElementRef } from '@angular/core';
import { Offer } from '../../MoelNg/Offer';
import { Categorie } from '../../MoelNg/Categorie';
import { NgForm, ReactiveFormsModule, FormGroup, FormControl, ValidationErrors, Validators} from '@angular/forms';
import { Http } from '@angular/http';
import { OfferService } from '../../services/OfferService';
import { Direction } from '../../MoelNg/Direction';
import { Commission } from '../../MoelNg/Commission';
import { Depouillement } from '../../MoelNg/Depouillement';
import { Plis } from '../../MoelNg/Plis';
import { CookieService } from 'ngx-cookie';
import { Router } from '@angular/router';
import { CategorieService } from '../../services/CategorieService';
import { DirectionService } from '../../services/DirectionService';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { FileService } from '../../services/FileServcie';
import { CommissionService } from '../../services/CommissionService';
import { BidderService } from '../../services/BidderService';
import { MailService } from '../../services/MailService';
import { Bidder } from '../../MoelNg/Bidder';
import { Address } from '../../MoelNg/Address';
import { Mail } from '../../MoelNg/Mail';
import { forEach } from '@angular/router/src/utils/collection';
import { saveAs } from 'file-saver';

@Component({
    selector: 'detailOffer',
    templateUrl: './detailOffer.component.html'
})
export class DetailOfferComponent implements OnInit {

    bidderForm: FormGroup;
    offerDetail: any;
    data: any;
    files: any;
    success: string = "";
    error: Error;
    bidder: Bidder;
    bidders: Array<Bidder>;
    bidderList: Array<Bidder>;
    bidderSelected: Array<Bidder>;
    categorieList: Array<Categorie>;
    directionList: Array<Direction>;
    commissionList: Array<Commission>;
    localDataUrl: SafeResourceUrl;
    typeEnterp: string[] = ["SARL", "EURL", "SELARL", "SA", "SAS", "SNC"];
    fileList: any;
    
    
    show: boolean;
    user: any;
    showList: boolean = false;
    email: Mail;
    enterpriseMail: string;
    mailAdd: number = 0;
    public loading = false;

    constructor( private mailService: MailService, private bidderService: BidderService, private commissionService: CommissionService,private fileService: FileService, private offerService: OfferService, private cookie: CookieService, private routage: Router, private categorieService: CategorieService, private directionService: DirectionService, private domSanitizer: DomSanitizer) {
       
        this.categorieList = new Array<Categorie>();
        this.directionList = new Array<Direction>();
        this.commissionList = new Array<Commission>();
        this.bidderList = new Array<Bidder>();
        this.bidders = new Array<Bidder>();
        this.bidderSelected = new Array<Bidder>();
        this.bidder = new Bidder();
        this.bidder.address = new Address();
        this.show = false;
        this.email = new Mail();
        this.email.destinations = new Array<string>();
        this.email.documents = new Array<string>();
      
        
        this.bidderForm = new FormGroup({
            'firstName': new FormControl(this.bidder.firstName, [Validators.required]),
            'lastName': new FormControl(this.bidder.lastName, [Validators.required]),
            'mail': new FormControl(this.bidder.email, [Validators.required, Validators.pattern("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)+$")]),
            'telephone': new FormControl(this.bidder.tel, [Validators.required, Validators.pattern("[0-9]{10}")]),
            'fax': new FormControl(this.bidder.fax, [Validators.required]),
            'domaine': new FormControl(this.bidder.domaine, [Validators.required]),
            'type': new FormControl(this.bidder.typeEnterprise, [Validators.required]),
            'street': new FormControl(this.bidder.address.street, [Validators.required]),
            'zip': new FormControl(this.bidder.address.zip, [Validators.required]),
            'city': new FormControl(this.bidder.address.city, [Validators.required]),
            'region': new FormControl(this.bidder.address.region, [Validators.required]),
            'country': new FormControl(this.bidder.address.country, [Validators.required]),
        })  
    }


    get firstName() { return this.bidderForm.get('firstName'); }
    get lastName() { return this.bidderForm.get('lastName'); }
    get mail() { return this.bidderForm.get('mail'); }
    get telephone() { return this.bidderForm.get('telephone'); }
    get fax() { return this.bidderForm.get('fax'); }
    get domaine() { return this.bidderForm.get('domaine'); }
    get type() { return this.bidderForm.get('type'); }
    get street() { return this.bidderForm.get('street'); }
    get zip() { return this.bidderForm.get('zip'); }
    get city() { return this.bidderForm.get('city'); }
    get region() { return this.bidderForm.get('region'); }
    get country() { return this; this.bidderForm.get('country'); }
  

    ngOnInit() {

        this.offerDetail = this.cookie.getObject("offer");
        console.log(this.offerDetail);
        this.user = this.cookie.getObject("CurrentUser");

        this.fileService.getFiles(this.offerDetail.id)
            .subscribe(res => {
                this.files = res;
                console.log(this.files);
            }); 

        this.bidderService.getListBidder()
            .subscribe(b => {
                this.bidderList = b;
                console.log(this.bidderList);
            });

        this.categorieService.getCategorie()
            .subscribe(x => { this.categorieList = x });

        this.directionService.getDirection()
            .subscribe(x => { this.directionList = x });

        this.commissionService.getCommission()
            .subscribe(c => { this.commissionList = c });
        console.log(this.commissionList);

        if (this.offerDetail.bidders.length == 0) {
            this.offerService.getOffer(this.offerDetail.id)
                .subscribe(d => {
                    this.offerDetail = d;
                    this.bidders = this.offerDetail.bidders;
                    console.log(this.bidders);

                });
        } else {
            this.bidders = this.offerDetail.bidders;
        }
    }

    onFormSubmit() {

        this.offerService.updateOffer(this.offerDetail)
            .subscribe(resp => {
                this.data = resp;
            }, error => this.error = error)
    }    

    AddMail() {
        this.email.destinations.push(this.enterpriseMail);
        this.mailAdd++;
        console.log(this.email.destinations);
    }

    SaveBidder() {
        console.log(this.bidder);

        this.bidder.offer = this.offerDetail;
        this.loading = true;

        this.bidderService.addBidder(this.bidder)
            .subscribe(resp => {
                this.bidder.id = resp
                this.bidders.push(this.bidder);
                this.loading = false;
            }, error => {
                this.error = error;
                this.loading = false;
            })

    }

   
    PublishOffer() {
        if (this.offerDetail.etat == "Ouvert") {

            if (window.confirm('Are you sure to publish this Offer?')) {
                this.offerDetail.publish = true;
                this.loading = true;
                this.offerService.updateOffer(this.offerDetail)
                    .subscribe(o => {
                        this.data = o;
                        if (this.data != null) {
                            this.success = "The Offer is published";
                        }
                        this.loading = false;
                    }, error => {
                        this.error = error
                        this.loading = false;
                    })
            }
        } else {
            this.showList = true;
        }
    }

    SelectedProvider(event: any) {
        this.bidderSelected
    }

    SendMail() {
        console.log(this.bidderSelected);
        this.email.author = "caohoangthang7@gmail.com";
        if (this.bidderSelected.length > 0) {
            for (var i = 0; i < this.bidderSelected.length; i++) {

                console.log(this.bidderSelected[i].email);
                this.email.destinations.push(this.bidderSelected[i].email);
                console.log(this.email);
            }          
        }
        
        this.offerDetail.publish = true;
        this.email.offer = this.offerDetail;
        for (var i = 0; i < this.files.length; i++) {
            this.email.documents.push(this.files[i].fileDownloadName);
        }
        console.log(this.email);
        this.loading = true;
        
        this.mailService.postMail(this.email)
            .subscribe(b => {
                this.data = b;
                if (this.data == true) {
                    this.success = "The Offer is published";                 
                }
                this.loading = false;
            }, error => {
                this.error = error;
                this.loading = false;
            });

        this.offerService.updateOffer(this.offerDetail)
            .subscribe(o => {
                this.data = o;
                this.loading = false;
            }, error => {
                this.error = error;
                this.loading = false;
            }) 
    }
}