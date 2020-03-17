import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";
import { Configuration } from "./Configuration";
import { Observable } from "rxjs/Observable";
import { Offer } from "../MoelNg/Offer";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class OfferService {

    public actionurl: string;


    constructor(private http: Http, private _configuration: Configuration) {

        this.actionurl = this._configuration.ServerWithApiUrl + '/Offer';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    
    public addOffer(item: Offer): Observable<boolean> {
      
        let formData = new FormData();
        console.log(item);

        for (var i = 0; i < item.documents.length; i++) {
            formData.append("files", item.documents[i]);
        }

        formData.append('code', item.code);
        formData.append('categorieId', item.categorie.id.toString());
       
        formData.append('directionId', item.direction.id.toString());
   
        formData.append('commissionId', item.commission.id.toString());
      
        formData.append('etat', item.etat);
        formData.append('intitule', item.intitule);
        formData.append('description', item.description);
        formData.append('placeDepot', item.placeDepot);
        formData.append('dateLimit', item.dateLimit.toString());
        formData.append('placeOpened', item.placeOpened);
        formData.append('dateOpened', item.dateOpened.toString());
        formData.append('manager', item.manager);
        formData.append('timeOpened', item.timeOpened);

        var header = new Headers({ 'Accept': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, formData, request)
            .map((x: Response) => {
                return <boolean>x.json(), 300000
            })
            .catch(this.handleError);
    }

    public getOffers(): Observable<Offer[]> {

        return this.http.get(this.actionurl)
            .map((x: Response) => {

                return <Offer[]>x.json()
            })
            .catch(this.handleError);
    }

    public getOffer(id: number): Observable<any> {


        return this.http.get(this.actionurl + '/' + id)
            .map((x: Response) => {

                return <any>x.json()
            })
            .catch(this.handleError);

    }

    public deleteOffer(id: number): Observable<boolean> {

        return this.http.delete(this.actionurl + '/' + id)
            .map((x: Response) => {
                return <boolean>x.json()
            })
    }

    public updateOffer(offer: Offer): Observable<boolean> {

        var toUpdate = JSON.stringify(offer);
        console.log(toUpdate);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Put, headers: header });

        return this.http.put(this.actionurl + '/' + offer.id, toUpdate, request)
            .map((x: Response) => {
                return <boolean>x.json()
            })
    }

}