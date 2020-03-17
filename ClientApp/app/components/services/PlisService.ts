import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Plis } from "../MoelNg/Plis";

@Injectable()
export class PlisService {

    public actionurl: string;


    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/Plis';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public postPlis(item: Plis): Observable<number> {
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


    public updatePlis(item: Plis): Observable<boolean> {

        var toUpdate = JSON.stringify(item);
        console.log(toUpdate);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Put, headers: header });

        return this.http.put(this.actionurl + '/' + item.id, toUpdate, request)
            .map((x: Response) => {
                return <boolean>x.json()
            }, 600000)
            .catch(this.handleError);
    }

    public deletePlis(id: number): Observable<boolean> {

        return this.http.delete(this.actionurl + '/' + id)
            .map((x: Response) => {
                return <boolean>x.json()
            })
            .catch(this.handleError);
    }

    public getPlis(id: number): Observable<Plis> {
        return this.http.get(this.actionurl + "/" + id)
            .map((x: Response) => {
                return <Plis>x.json()
            })
            .catch(this.handleError);
    }
}