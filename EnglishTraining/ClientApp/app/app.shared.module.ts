import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DevExtremeModule } from 'devextreme-angular'; 

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { VerbsComponent } from './components/verbs/verbs.component';
import { NotificationComponent } from './components/notification/notification.component';

import { VerbsResolver } from './services/verbs/verbs.resolver';
import { VerbsService } from './services/verbs/verbs.service';
import { HttpInterceptor } from './services/httpInterceptor';
import { NotificationService } from './services/notification.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VerbsComponent,
        NotificationComponent
    ],
    providers: [
        VerbsResolver,
        VerbsService,
        HttpInterceptor,
        NotificationService
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        DevExtremeModule,
        BrowserAnimationsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'verbs', component: VerbsComponent, resolve: { verbs: VerbsResolver } },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
