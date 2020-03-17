import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Categorie } from "../MoelNg/Categorie";
import { Direction } from "../MoelNg/Direction";

@Injectable()
export class HistoryService {

    public actionurl: string;


    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/History';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public getOffer(offerId: number): Observable<any> {

        return this.http.get(this.actionurl + '/' + offerId)
            .map((x: Response) => {

                return <any>x.json()
            })
            .catch(this.handleError);

    }

}