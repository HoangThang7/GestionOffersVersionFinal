import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod, ResponseContentType } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Offer } from "../MoelNg/Offer";
import { Authenticater } from "../MoelNg/Authenticater";
import { User } from "../MoelNg/User";
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class FileService {

    public actionurl: string;


    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/Files';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public getFiles(id: number): Observable<any> {
        let options = new RequestOptions({ responseType: ResponseContentType.Json });
        return this.http.get(this.actionurl + '/' + id, options)
            .map((res: Response) => {
                return <any>res.json();
            })
            .catch(this.handleError);
    }

   
}