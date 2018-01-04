import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Http, Request, RequestOptions, RequestOptionsArgs, Response, XHRBackend, Headers } from "@angular/http"
import { Injectable } from "@angular/core"
import 'rxjs/add/operator/catch';

@Injectable()
export class HttpInterceptor extends Http {

    constructor(//private authenticationService: AuthenticationService,
        backend: XHRBackend,
        options: RequestOptions,
        public http: Http,
        private router: Router) {

        super(backend, options);
    }

    public request(url: string | Request, options?: RequestOptionsArgs): Observable<Response> {

        if (typeof url === 'object') { // Не учтено, если url придет как строка!

            //url.headers.append('Authorization', `Bearer ${this.authenticationService.token}`);
            url.headers.append('Content-Type', 'application/json');
        }
        return super.request(url, options)
            .catch(this.handleError)
    }

    protected handleError(err: any) {
        if (err.status === 401) {
            //this.authenticationService.logout();
            this.router.navigate(['/signin']);
        }
        return Observable.throw(err);
    }
}
