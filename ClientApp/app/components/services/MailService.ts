import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Mail } from "../MoelNg/Mail";

@Injectable()
export class MailService {

    public actionurl: string;


    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/Mail';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public postMail(item: Mail): Observable<boolean> {

        var toMail = JSON.stringify(item);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toMail, request)
            .map((x: Response) => {
                return <boolean>x.json()
            })
            .catch(this.handleError);
    }

}