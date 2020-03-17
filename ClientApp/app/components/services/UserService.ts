import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestMethod, RequestOptions } from '@angular/http';
import { Configuration } from './Configuration';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { User } from '../MoelNg/User';


@Injectable()
export class UserService {

    public actionurl: string;
    
    constructor(private http: Http) {

        this.actionurl = 'http://localhost:50748/api' + '/User';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public getUser(email: string): Observable<any> {
        return this.http.get(this.actionurl + '/' + email)    
            .map((x: Response) => <any>x.json())
            .catch(this.handleError);
       
    }

    public addUser(item: User): Observable<any> {
        var toAdd = JSON.stringify(item);
        console.log(toAdd);
        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toAdd, request)
            .map((x: Response) => {
                return <any>x.json()
            })
            .catch(this.handleError);            
    };

    public getListUser(): Observable<User[]> {
       
        return this.http.get(this.actionurl)
            .map((x: Response) => { 
                return <User[]>x.json()
            })
            
            .catch(this.handleError);
    }

    public deleteUser(id: number): Observable<boolean> {
        console.log(id);
        return this.http.delete(this.actionurl + '/' + id)
            .map((x: Response) => {
               return <boolean>x.json();
            })
            .catch(this.handleError);
    }

    public updateUser(user: User): Observable<any> {
        
        var toUpdate = JSON.stringify(user);
        console.log(toUpdate);

        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Put, headers: header });

        return this.http.put(this.actionurl + '/' + user.id, toUpdate, request)
            .catch(this.handleError);
    }

}

