import { Component, OnInit } from "@angular/core";
import { UserService } from "../../Services/UserService";
import { User } from "../../MoelNg/User";
import { Commission } from "../../MoelNg/Commission";
import { CommissionService } from "../../services/CommissionService";
import { FormsModule, NgForm, FormBuilder, FormGroup, Validators, FormControl, ValidatorFn, AbstractControl } from '@angular/forms';



@Component({
    selector: 'commission',
    templateUrl: './commission.component.html'
})
export class CommissionComponent implements OnInit {

    users: Array<User>;
    memberCommis: Array<User>;
    commission: Commission;
    newCommis: any;
    commissions: Commission[];
    members: Array<User>;
    error: Error;
    comisForm: FormGroup;
    loading: boolean = false;

    constructor(private userService: UserService, private commissionService: CommissionService) {
        this.users = new Array<User>();
        this.memberCommis = new Array<User>();
        this.commission = new Commission();
        this.commission.members = new Array<User>();
        this.members = new Array<User>();
        this.commissions = new Array<Commission>();
        

        this.comisForm = new FormGroup({
            'code': new FormControl(this.commission.code, [Validators.required, Validators.minLength(8), Validators.maxLength(8), Validators.pattern("^[A-Z]{2}[0-9]{6}$"), this.CodeUnique.bind(this)]),
            'libelle': new FormControl(this.commission.libelle, [Validators.required]),
            'member': new FormControl(this.memberCommis, [Validators.required]),
        });
    }

    ngOnInit() {
        this.userService.getListUser()
            .subscribe(resp => {
                this.users = resp
                for (var i = 0; i < this.users.length; i++) {
                    if (this.users[i].type == 2 || this.users[i].type == 1) {
                        this.members.push(this.users[i]);
                        console.log(this.members);
                    }
                }
            }
        );

        this.commissionService.getCommission()
            .subscribe(c => {
                this.commissions = c;
                console.log(this.commissions);
            })

    }

    get code() { return this.comisForm.get('code'); }
    get libelle() { return this.comisForm.get('libelle'); }
    get member() { return this.comisForm.get('member'); }

    selectedUser(event: any) {
        this.memberCommis
    }

    onFormSubmit(form: NgForm) {
        this.commission.members = this.memberCommis;
        
        console.log(this.commission);
        this.loading = true;
        this.commissionService.addCommmission(this.commission)
            .subscribe(x => {
                this.newCommis = x
                this.loading = false;
            }, error => {
                this.error = error;
                this.loading = false;
            })
    }

    CodeUnique(c: FormControl) {

        let co
        if (this.commissions) {
            co = this.commissions.find(com => com.code == c.value);
        }
        return !co ? null : { CodeTaken: true }
    }
}