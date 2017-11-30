import { Injectable } from '@angular/core';
import {
    Router, Resolve, RouterStateSnapshot,
    ActivatedRouteSnapshot
} from '@angular/router';
import { Verb } from '../../models/verbs/verbs.model';
import { VerbsService } from '../verbs/verbs.service';

@Injectable()
export class VerbsResolver implements Resolve<Verb[]> {

    constructor(private verbsService: VerbsService,
        private router: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<Verb[]> {

        return this.verbsService.getVerbs().toPromise();
    }
}