import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Categorie } from "../MoelNg/Categorie";
import { Direction } from "../MoelNg/Direction";
import { Configuration } from "./Configuration";

@Injectable()
export class DirectionService {

    public actionurl: string;


    constructor(private http: Http, private _configuration: Configuration) {

        this.actionurl = this._configuration.ServerWithApiUrl + '/Direction';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public getDirection(): Observable<Direction[]> {
        return this.http.get(this.actionurl)
            .map((x: Response) => {
                return <Direction[]>x.json() })
            .catch(this.handleError);
    }

}