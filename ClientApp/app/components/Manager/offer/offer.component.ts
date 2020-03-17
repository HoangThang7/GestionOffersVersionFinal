import { Component, ViewChild, OnInit } from '@angular/core';
import { Offer } from '../../MoelNg/Offer';
import { Categorie } from '../../MoelNg/Categorie';
import { FormsModule, NgForm, FormBuilder, FormGroup, Validators, FormControl, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { Http } from '@angular/http';
import { OfferService } from '../../services/OfferService';
import { CategorieService } from '../../services/CategorieService';
import { DirectionService } from '../../services/DirectionService';
import { Direction } from '../../MoelNg/Direction';
import { Commission } from '../../MoelNg/Commission';
import { CommissionService } from '../../services/CommissionService';
import { CookieService } from 'ngx-cookie';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'offer',
    templateUrl: './offer.component.html'
})
export class AddOfferComponent implements OnInit {

    newOffer: Offer;
    selectedFiles: string[];
    filesToUpload: Array<File>;
    categorieList: Array<Categorie>;
    directionList: Array<Direction>;
    commissionList: Array<Commission>;
    offer: any;
    formData: FormData;
    error: Error;
    manager: any;
    etatOffer: string[] = ["Ouvert", "Consultation"];
    offerForm: FormGroup;
    taille: string;
    offers: Offer[];
    loading: boolean = false;

    constructor(private commissionService: CommissionService, private offerService: OfferService, private categorieService: CategorieService, private directionService: DirectionService, private cookie: CookieService) {
        this.newOffer = new Offer();
        this.newOffer.categorie = new Categorie();
        this.newOffer.direction = new Direction();
        this.newOffer.commission = new Commission();
        this.newOffer.documents = new Array<File>();
        this.categorieList = new Array<Categorie>();
        this.directionList = new Array<Direction>();
        this.commissionList = new Array<Commission>();
        this.selectedFiles = [];
        this.filesToUpload = [];
        this.formData = new FormData();
        this.offers = new Array<Offer>();

        this.offerForm = new FormGroup({
            'code': new FormControl(this.newOffer.code, [Validators.required, Validators.minLength(8), Validators.maxLength(8), Validators.pattern("^[A-Z]{2}[0-9]{6}$"), this.CodeUnique.bind(this)]),
            'categorie': new FormControl(this.newOffer.categorie, [Validators.required]),
            'direction': new FormControl(this.newOffer.direction, [Validators.required]),
            'commission': new FormControl(this.newOffer.commission, [Validators.required]),
            'etat': new FormControl(this.newOffer.etat, [Validators.required]),
            'intitule': new FormControl(this.newOffer.intitule, [Validators.required]),
            'description': new FormControl(this.newOffer.description, [Validators.required]),
            'placeDepot': new FormControl(this.newOffer.placeDepot, [Validators.required]),
            'dateLimit': new FormControl(this.newOffer.dateLimit, [Validators.required]),
            'placeOpened': new FormControl(this.newOffer.placeOpened, [Validators.required]),
            'dateOpened': new FormControl(this.newOffer.dateOpened, [Validators.required]),
        })     
      
    }

    ngOnInit() {
      

        this.commissionService.getCommission()
            .subscribe(c => { this.commissionList = c });
        console.log(this.commissionList);

        this.categorieService.getCategorie()
            .subscribe(x => { this.categorieList = x });
        console.log(this.categorieList);

        this.directionService.getDirection()
            .subscribe(x => { this.directionList = x });
        console.log(this.directionList);

        
        this.offerService.getOffers().
            subscribe(x => {
                this.offers = x;
                console.log(this.offers);
            })
        
    }

    get code() { return this.offerForm.get('code'); }
    get categorie() { return this.offerForm.get('categorie'); }
    get direction() { return this.offerForm.get('direction'); }
    get commission() { return this.offerForm.get('commission'); }
    get etat() { return this.offerForm.get('etat'); }
    get intitule() { return this.offerForm.get('intitule'); }
    get description() { return this.offerForm.get('description'); }
    get placeDepot() { return this.offerForm.get('placeDepot'); }
    get dateLimit() { return this.offerForm.get('dateLimit'); }
    get placeOpened() { return this.offerForm.get('placeOpened'); }
    get dateOpened() { return this.offerForm.get('dateOpened'); }
    

    CodeUnique(control: FormControl) {
       
        let off;
        if (this.offers) {
            off = this.offers.find(e => e.code == control.value)
        }
            return !off ? null : { CodeTaken: true };
    }
    

    fileUpload(event: any) {

        this.filesToUpload = <Array<File>>event.target.files;

        for (var i = 0; i < this.filesToUpload.length; i++) {
            this.selectedFiles.push(this.filesToUpload[i].name);
        }

    }

    upload() {
        if (this.filesToUpload.length == 0) {
            alert('Please select at least 1 PDF files to upload!');
        }
        if (this.filesToUpload.length > 0) {
            for (var i = 0; i < this.filesToUpload.length; i++) {
                if (this.filesToUpload[i].size > 2500000) {
                    this.taille = "La taille de fichier est trop grande";
                } else {
                    this.taille = "Ok";
                    this.newOffer.documents.push(this.filesToUpload[i]);
                }
            }
        }

    }

    cancelUpload() {
        this.filesToUpload = [];
        this.selectedFiles = [];
        this.newOffer.documents = [];
    }


    onFormSubmit() {

        console.log(this.offerForm);
        console.log(this.newOffer);
        this.manager = this.cookie.getObject("CurrentUser");
        this.newOffer.manager = this.manager.mail;
        this.newOffer.publish = false;
        this.loading = true;

        this.offerService.addOffer(this.newOffer)
            .subscribe(x => {
                this.offer = x
                this.loading = false;
            }, error => {
                this.error = error;
                this.loading = false;
            })
       
    }
}