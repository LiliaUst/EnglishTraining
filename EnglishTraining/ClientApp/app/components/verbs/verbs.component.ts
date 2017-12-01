import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Verb, TenseVerbs, PersonVerbs, NumberVerbs } from '../../models/verbs/verbs.model';

@Component({
    styleUrls: ['./verbs.component.css'],
    selector: 'verbs-component',
    templateUrl: './verbs.component.html'
})
export class VerbsComponent {
    verbs: Verb[];
    currentVerb: Verb = new Verb();
    public tenseVerbs = TenseVerbs;
    public personVerbs = PersonVerbs;
    public numberVerbs = NumberVerbs;
    showPanel: boolean = false;

    constructor(private route: ActivatedRoute) {
        //DevExpress.viz.currentTheme(DevExpress.devices.current(), 'light');
    }

    ngOnInit() {

        this.route.data
            .subscribe((data: { verbs: Verb[] }) => {
                
                this.verbs = data.verbs;
                
                //console.log(this.verbs)
            });
    }

    isTense(tense: TenseVerbs): boolean {
        return this.currentVerb && this.currentVerb.verbForms[tense];
    }

    hasCurrenVerb() {
        return typeof this.currentVerb.id !== 'undefined';
    }

    onVerbSelectionChange(e: any) {
        
        this.currentVerb = e.selectedRowsData[0];
        this.showPanel = true;
        console.log(this.currentVerb);
    }

    onFirstSingularValueChanged(e: any) {
        this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.Second][NumberVerbs.Singular].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.First][NumberVerbs.Plural].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.Second][NumberVerbs.Plural].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.Third][NumberVerbs.Plural].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.First][NumberVerbs.Singular].verbEn;
    }

    onSave(e: any) {

        var resultValidation = e.validationGroup.validate();
        if (!resultValidation.isValid)
            return;
        console.info(this.currentVerb);
    }
}
