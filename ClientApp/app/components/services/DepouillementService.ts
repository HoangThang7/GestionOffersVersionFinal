import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Depouillement } from "../MoelNg/Depouillement";

@Injectable()
export class DepouillementService {

    public actionurl: string;

    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/Depouillement';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public addDepouillement(item: Depouillement): Observable<number> {
        var toAdd = JSON.stringify(item);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toAdd, request)
            .map((x: Response) => {
                return <number>x.json()
            })
            .catch(this.handleError);
    }

    public getDepouille(id: number): Observable<any> {

        return this.http.get(this.actionurl + '/' + id)
            .map((x: Response) => {
                return <any>x.json()
            })
            .catch(this.handleError);
    }

    public deleteDepouille(id: number): Observable<boolean> {

        return this.http.delete(this.actionurl + '/' + id)
            .map((x: Response) => {
                return <boolean>x.json()
            })
    }

    public updateDepouille(depouille: Depouillement): Observable<boolean> {

        var toUpdate = JSON.stringify(depouille);
        console.log(toUpdate);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Put, headers: header });

        return this.http.put(this.actionurl + '/' + depouille.id, toUpdate, request)
            .map((x: Response) => {
                return <boolean>x.json()
            })
    }
}