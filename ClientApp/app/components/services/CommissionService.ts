import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Categorie } from "../MoelNg/Categorie";
import { Commission } from "../MoelNg/Commission";
import { Configuration } from "./Configuration";

@Injectable()
export class CommissionService {

    public actionurl: string;


    constructor(private http: Http, private _configuration: Configuration) {

        this.actionurl = this._configuration.ServerWithApiUrl + '/Commission';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public addCommmission(item: Commission): Observable<boolean> {
        var toAdd = JSON.stringify(item);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toAdd, request)
            .map((x: Response) => {
                return <boolean>x.json()
            })
            .catch(this.handleError);

    }

    public getCommission(): Observable<Commission[]> {
        return this.http.get(this.actionurl)
            .map((x: Response) => {
                return <Commission[]>x.json()
            })
            .catch(this.handleError);
    }

    public deleteCommis(comisId: number): Observable<boolean> {
        return this.http.delete(this.actionurl + '/' + comisId)
            .map((c: Response) => {
                return <boolean>c.json()
            })
            .catch(this.handleError);
    }
}