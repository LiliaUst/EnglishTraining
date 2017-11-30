import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Verb } from '../../models/verbs/verbs.model';

@Component({
    selector: 'verbs-component',
    templateUrl: './verbs.component.html'
})
export class VerbsComponent {
    verbs: Verb[];

    constructor(private route: ActivatedRoute) {
        //DevExpress.viz.currentTheme(DevExpress.devices.current(), 'light');
    }

    ngOnInit() {

        this.route.data
            .subscribe((data: { verbs: Verb[] }) => {
                this.verbs = data.verbs;
                console.log(this.verbs)
            });
    }
}
