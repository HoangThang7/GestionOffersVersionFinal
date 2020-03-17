import { Injectable } from "@angular/core";
import { Http, Headers, Response, RequestOptions, RequestMethod } from "@angular/http";

import { Observable } from "rxjs/Observable";
import { Categorie } from "../MoelNg/Categorie";
import { Commission } from "../MoelNg/Commission";
import { Contract } from "../MoelNg/Contract";

@Injectable()
export class ContractService {

    public actionurl: string;


    constructor(private http: Http) {
        this.actionurl = 'http://localhost:50748/api' + '/Contract';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public addContract(item: Contract): Observable<number> {
        var toAdd = JSON.stringify(item);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toAdd, request)
            .map((x: Response) => {
                return <number>x.json()
            })
            .catch(this.handleError);
    }

    public getContract(id: number): Observable<Contract> {

        return this.http.get(this.actionurl + '/' + id)
            .map((x: Response) => {
                return <Contract>x.json()
            })
            .catch(this.handleError);
    }

    public deleteContract(id: number): Observable<boolean> {

        return this.http.delete(this.actionurl + '/' + id)
            .map((x: Response) => {
                return <boolean>x.json()
            })
    }

    public updateContract(contract: Contract): Observable<boolean> {

        var toUpdate = JSON.stringify(contract);
        console.log(toUpdate);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Put, headers: header });

        return this.http.put(this.actionurl + '/' + contract.id, toUpdate, request)
            .map((x: Response) => {
                return <boolean>x.json()
            })
    }
}