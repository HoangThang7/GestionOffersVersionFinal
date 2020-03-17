import { NgModule, Pipe, PipeTransform} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/Admin/navmenu/navmenu.component';
import { ProfilComponent } from './components/Admin/profil/profil.component';
import { FetchDataComponent } from './components/Admin/fetchdata/fetchdata.component';
import { AddUserComponent } from './components/Admin/counter/addUser.component';
import { UserService } from './components/Services/UserService';
import { BrowserModule } from '@angular/platform-browser';
import { HomeComponent } from './components/home/home.component';
import { CookieModule } from 'ngx-cookie';
import { UserComponent } from './components/Admin/detailUser/detail.component';
import { NavManagComponent } from './components/Manager/navig/navManag.component';
import { AddOfferComponent } from './components/Manager/offer/offer.component';
import { OfferService } from './components/services/OfferService';
import { CategorieService } from './components/services/CategorieService';
import { DirectionService } from './components/services/DirectionService';
import { CommissionComponent } from './components/Manager/commission/commission.component';
import { CommissionService } from './components/services/CommissionService';
import { FetchOfferComponent } from './components/Manager/fetchoffer/fetchoffer.component';
import { DetailOfferComponent } from './components/Manager/detailoffer/detailOffer.component';
import { FileService } from './components/services/FileServcie';
import { BidderService } from './components/services/BidderService';
import { PlisService } from './components/services/PlisService';
import { MailService } from './components/services/MailService';
import { ContractService } from './components/services/ContractService';
import { DepouillementService } from './components/services/DepouillementService';
import { FetchComisComponent } from './components/Manager/fetchcomission/fetchComis.component'
import { OfferListComponent } from './components/Enterprise/offers/offerlist.component';
import { NavEntComponent } from './components/Enterprise/navmenu/navEnt.component';
import { OfferDetailComponent } from './components/Enterprise/detailoffer/offerDetail.component';
import { NavUserComponent } from './components/User/navig/navigUser.component';
import { DetailBidderComponent } from './components/Manager/detailBidder/detailBid.component';
import { DepouilleComponent } from './components/Manager/depouillement/depouillement.component';
import { ContractComponent } from './components/Manager/contract/contract.component';
import { HistoryComponent } from './components/Manager/history/history.component';
import { LoadingModule } from 'ngx-loading';
import { FilterPipe } from './components/Manager/fetchoffer/filterPipe';
import { AddEnterpriseComponent } from './components/Enterprise/addEnterprise/addEnterprise.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { AuthGuard } from '../app/components/services/AuthGuard';
import { FilterPipeUser } from './components/Admin/fetchdata/filterPipeUser';
import { AuthService } from './components/services/AuthService';
import { HistoryService } from './components/services/HistoryService';
import { Configuration } from './components/services/Configuration';


@NgModule({
    declarations: [
        AppComponent,
        FilterPipe,
        FilterPipeUser,
        NavMenuComponent,
        AddUserComponent,
        FetchDataComponent,
        ProfilComponent,
        DepouilleComponent,
        HomeComponent,
        UserComponent,
        NavManagComponent,
        AddOfferComponent,
        CommissionComponent,
        DetailOfferComponent,
        FetchOfferComponent,
        OfferListComponent,
        OfferDetailComponent,
        NavEntComponent,
        NavUserComponent,
        DetailBidderComponent,
        ContractComponent,
        HistoryComponent,
        FetchComisComponent,
        AddEnterpriseComponent
    ],
    imports: [              
        NgxPaginationModule,
        LoadingModule,
        ReactiveFormsModule,
        CommonModule,
        HttpModule,
        FormsModule,
        BrowserModule,
        CookieModule.forRoot(),
        RouterModule.forRoot([
            { path: '', component: HomeComponent },
            { path: 'profil', component: ProfilComponent, canActivate: [AuthGuard] },
            { path: 'detail', component: UserComponent, canActivate: [AuthGuard] },
            { path: 'add', component: AddUserComponent, canActivate: [AuthGuard] },
            { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard]  },
            { path: 'offer', component: AddOfferComponent, canActivate: [AuthGuard]  },
            { path: 'commission', component: CommissionComponent, canActivate: [AuthGuard]  },
            { path: 'fetchoffer', component: FetchOfferComponent, canActivate: [AuthGuard]  },
            { path: 'detailOffer', component: DetailOfferComponent, canActivate: [AuthGuard]  },
            { path: 'offerlist', component: OfferListComponent, canActivate: [AuthGuard]  },
            { path: 'offerDetail/:id', component: OfferDetailComponent, canActivate: [AuthGuard]  },
            { path: 'detailbidder/:id', component: DetailBidderComponent, canActivate: [AuthGuard]  },
            { path: 'fetchcommis', component: FetchComisComponent, canActivate: [AuthGuard]  },
            { path: 'depouille', component: DepouilleComponent, canActivate: [AuthGuard]  },
            { path: 'contract/:id', component: ContractComponent, canActivate: [AuthGuard] },
            { path: 'history', component: HistoryComponent, canActivate: [AuthGuard] },
            { path: 'register', component: AddEnterpriseComponent },
            { path: '**', redirectTo: '/profil' }
        ])
    ],
    providers: [    
        Configuration,
        HistoryService,
        AuthService,
        AuthGuard,
        MailService,
        PlisService,      
        BidderService,
        FileService,
        UserService,
        OfferService,
        CategorieService,
        DirectionService,
        CommissionService,
        ContractService,
        DepouillementService  
    ]
})
export class AppModuleShared {
}


