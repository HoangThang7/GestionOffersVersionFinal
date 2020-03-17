import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Categorie } from "../MoelNg/Categorie";
import { Configuration } from "./Configuration";

@Injectable()
export class CategorieService {

    public actionurl: string;


    constructor(private http: Http, private _configuration: Configuration) {

        this.actionurl = this._configuration.ServerWithApiUrl + '/Categorie';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public getCategorie(): Observable<Categorie[]> {
        return this.http.get(this.actionurl)
            .map((x: Response) => {
                return <Categorie[]>x.json()
            })
            .catch(this.handleError);
    }

}

