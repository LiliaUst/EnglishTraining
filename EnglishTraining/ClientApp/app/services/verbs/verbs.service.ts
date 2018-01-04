import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Verb } from '../../models/verbs/verbs.model';
import { HttpInterceptor } from '../httpInterceptor';
import { Router } from '@angular/router';
import { VerbSaveResult } from '../../models/verbs/verb.result';

@Injectable()
export class VerbsService {

    private baseUrl: string = `/api/verbs`;

    constructor(private http: HttpInterceptor,
        router: Router) {
    }

    public getVerbs(): Observable<Verb[]> {

        return this.http.get(`${this.baseUrl}/getVerbs/`)
            .map((res: Response) => {
                return <Verb[]>res.json();
            });
    }

    public saveVerb(model: Verb): Observable<VerbSaveResult> {
        return this.http.post(`${this.baseUrl}/saveVerb`, JSON.stringify(model))
            .map((response: Response) => {
                return <VerbSaveResult>response.json();
            });
    }
}
