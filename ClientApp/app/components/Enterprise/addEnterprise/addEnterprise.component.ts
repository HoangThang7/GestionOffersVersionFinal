import { Component } from '@angular/core';
import { UserService } from '../../Services/UserService';
import { NgForm, ReactiveFormsModule, FormGroup, FormControl, ValidationErrors, Validators } from '@angular/forms';
import { User } from '../../MoelNg/User';
import { Address } from '../../MoelNg/Address';
import { Provider } from '../../MoelNg/Provider';


@Component({
    selector: 'addEnterp',
    templateUrl: './addEnterprise.component.html'
})
export class AddEnterpriseComponent {


    error: Error;
    userForm: FormGroup;
    newUser: User;
    data: any;
    users: User[];
    pswConfirm: string;
    loading: boolean = false;

    constructor(private userService: UserService) {
        this.newUser = new User();
        this.newUser.address = new Address();
        this.newUser.provider = new Provider();
        this.users = new Array<User>();
        this.pswConfirm = "";

        this.userService.getListUser()
            .subscribe(resp => {
                this.users = resp
            });

        this.userForm = new FormGroup({
            'firstName': new FormControl(this.newUser.firstName, [Validators.required]),
            'lastName': new FormControl(this.newUser.lastName, [Validators.required]),
            'email': new FormControl(this.newUser.mail, [Validators.required, Validators.pattern("^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)+$"), this.EmailUnique.bind(this)]),
            'password': new FormControl(this.newUser.password, [Validators.required, Validators.maxLength(8)]),
            'paswConfirm': new FormControl(this.pswConfirm, [Validators.required, this.ConfirPasw.bind(this)]),
            'telephone': new FormControl(this.newUser.numberTel, [Validators.required]),
            'date': new FormControl(this.newUser.date, [Validators.required]),
            'street': new FormControl(this.newUser.address.street, [Validators.required]),
            'zip': new FormControl(this.newUser.address.zip, [Validators.required]),
            'city': new FormControl(this.newUser.address.city, [Validators.required]),
            'region': new FormControl(this.newUser.address.region, [Validators.required]),
            'country': new FormControl(this.newUser.address.country, [Validators.required]),
            'fax': new FormControl(this.newUser.provider.fax, [Validators.required]),
            'domaine': new FormControl(this.newUser.provider.domaine, [Validators.required]),
            'typeEnterprise': new FormControl(this.newUser.provider.typeEnterprise, [Validators.required]),
        })
    }

    get firstName() { return this.userForm.get('firstName'); }
    get lastName() { return this.userForm.get('lastName'); }
    get email() { return this.userForm.get('email'); }
    get password() { return this.userForm.get('password'); }
    get paswConfirm() { return this.userForm.get('paswConfirm'); }
    get telephone() { return this.userForm.get('telephone'); }
    get date() { return this.userForm.get('date'); }
    get street() { return this.userForm.get('street'); }
    get zip() { return this.userForm.get('zip'); }
    get city() { return this.userForm.get('city'); }
    get region() { return this.userForm.get('region'); }
    get country() { return this.userForm.get('country'); }
    get fax() { return this.userForm.get('fax'); }
    get domaine() { return this.userForm.get('domaine'); }
    get typeEnterprise() { return this.userForm.get('typeEnterprise'); }

    onFormSubmit() {

        console.log(this.newUser);
        this.newUser.firstName.toLocaleUpperCase();
        this.newUser.lastName.toLocaleUpperCase();
        this.loading = true;
        this.userService.addUser(this.newUser)
            .subscribe(
                (resp: Response) => {
                    this.data = resp
                    this.loading = false
                }, error => {
                    this.error = error;
                    this.loading = false;
                }
            );
    }

    EmailUnique(c: FormControl) {

        let user;
        if (this.users) {

            user = this.users.find(u => u.mail == c.value);

        }
        return !user ? null : { EmailTaken: true };
    }

    ConfirPasw(c: FormControl) {

        return this.newUser.password == this.pswConfirm ? null : { NotSamePasw: true };
    }

}
