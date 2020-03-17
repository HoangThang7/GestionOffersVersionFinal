import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Categorie } from "../MoelNg/Categorie";
import { Bidder } from "../MoelNg/Bidder";

@Injectable()
export class BidderService {

    public actionurl: string;


    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/Bidder';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public addBidder(item: Bidder): Observable<number> {
        var toAdd = JSON.stringify(item);
        console.log(toAdd);
        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toAdd, request)
            .map((x: Response) => {
                return <number>x.json()
            })
            .catch(this.handleError);

    }

    public getBidder(Id: number): Observable<Bidder> {
        return this.http.get(this.actionurl + '/' + Id)
            .map((x: Response) => {
                return <Bidder>x.json()
            })
            .catch(this.handleError);
    }

    public updateBid(item: Bidder): Observable<Bidder> {

        var toUpdate = JSON.stringify(item);
        console.log(toUpdate);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Put, headers: header });

        return this.http.put(this.actionurl + '/' + item.id, toUpdate, request)
            .map((x: Response) => {
                return <Bidder>x.json()
            }, 600000)
            .catch(this.handleError);
    }

    public getListBidder(): Observable<Bidder[]> {

        return this.http.get(this.actionurl)
            .map((x: Response) => {
                return <Bidder[]>x.json()
            })
            .catch(this.handleError);
    }
}
