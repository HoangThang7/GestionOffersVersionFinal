import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Authenticater } from '../MoelNg/Authenticater';
import { Headers, Http, Response, RequestOptions, RequestMethod, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthService {


    public actionurl: string;


    constructor(private http: Http, private router: Router,
        private route: ActivatedRoute) {
        this.actionurl = 'http://localhost:50748/api' + '/Authenticate';
    }

    public handleError(error: Response | any) {
        console.error('ApiService::handleError', error);
        return Observable.throw(error);
    }

    public identifyUser(item: Authenticater): Observable<any> {
        var toAdd = JSON.stringify(item);
        console.log(toAdd);
        var header = new Headers({ 'Content-type': 'application/json' });
        var request = new RequestOptions({ method: RequestMethod.Post, headers: header });

        return this.http.post(this.actionurl, toAdd, request)
            .map((x: Response) => {
                return <any>x.json()
            })
            .catch(this.handleError);

    }

logout() {

    this.clearUser();
    this.router.navigate(['/home']);
}


setUser(user: any) {
    localStorage.setItem('User', JSON.stringify(user));
}

clearUser() {
    localStorage.removeItem('User');
}

}