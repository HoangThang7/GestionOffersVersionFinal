import { Component, Input } from '@angular/core';
import { FileService } from '../services/FileServcie';
import { Router, ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie';
import { User } from '../MoelNg/User';
import { Authenticater } from '../MoelNg/Authenticater';
import { Provider } from '../MoelNg/Provider';
import { Address } from '../MoelNg/Address';
import { AuthService } from '../services/AuthService';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',           
    styleUrls: ['./home.component.css'],
    providers: [AuthService]
})
export class HomeComponent {

    user: any;
    authenticater: Authenticater;
    pwd: string;
    errorAuth: string;
    loading: boolean = false;

    constructor(private authSer: AuthService, private loginService: AuthService, private router: Router, private cookieService: CookieService, private route: ActivatedRoute) {
       
        this.authenticater = new Authenticater();
    }

    public GetLogin() {

        this.loading = true;
        return this.loginService.identifyUser(this.authenticater)

            .subscribe((x: Response) => {
                this.user = x
                console.log(this.user)

                if (this.user.mail) {
                  
                      this.cookieService.putObject('CurrentUser', this.user);
                    console.log(this.cookieService.get('CurrentUser'));
                    this.loading = false;
                    localStorage.setItem("User", this.user.mail);
                    console.log(localStorage.getItem("User"));
                    const redirectUrl = this.route.snapshot.queryParams['redirectUrl'] || '/profil';

                    // On accède à la page souhaitée
                    this.router.navigate([redirectUrl]);                               
                                            
              } else {
                  this.errorAuth =  "L\'identifiant et mot de passe ne correspond pas";
                  this.loading = false;
                }

            });

    }

    Register() {
        this.router.navigate(['/register']);
    }
}