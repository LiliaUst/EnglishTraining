import { Component, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Verb, TenseVerbs, PersonVerbs, NumberVerbs } from '../../models/verbs/verbs.model';
import { NotificationService } from '../../services/notification.service';
import { VerbsService } from '../../services/verbs/verbs.service';
import { VerbTab, VerbTabId } from '../../models/verbs/verbtab';

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
    verbTabs: VerbTab[] = [
        { id: 1, text: "Infinitive", content: "" },
        { id: 2, text: "Present Simple", content: "" }
    ];
    currentVerbTab: number = VerbTabId.Inifinitive;
    public verbTabId = VerbTabId;
    selectedVerbs: any = [];
    selectedVerb: Verb;

    constructor(private route: ActivatedRoute,
        private notificationService: NotificationService,   
        private verbsService: VerbsService) {
        //DevExpress.viz.currentTheme(DevExpress.devices.current(), 'light');
    }

    ngOnInit() {

        this.route.data
            .subscribe((data: { verbs: Verb[] }) => {
                
                this.verbs = data.verbs;
            });
    }

    isTense(tense: TenseVerbs): boolean {
        return this.currentVerb && this.currentVerb.verbForms[tense];
    }

    hasCurrenVerb() {
        return typeof this.currentVerb.id !== 'undefined';
    }

    onVerbSelectionChange(e: any) {
       
        this.currentVerb = JSON.parse(JSON.stringify(e.selectedRowsData[0]));
        this.selectedVerb = e.selectedRowsData[0];

        this.showPanel = true;
    }

    onFirstSingularValueChanged(e: any) {
        this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.Second][NumberVerbs.Singular].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.First][NumberVerbs.Plural].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.Second][NumberVerbs.Plural].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.Third][NumberVerbs.Plural].verbEn
            = this.currentVerb.verbForms[TenseVerbs.PresentSimple][PersonVerbs.First][NumberVerbs.Singular].verbEn;
    }

    onSelectTab(e: any) {

        this.currentVerbTab = e.itemData.id;
    }

    onSave(e: any) {

        var resultValidation = e.validationGroup.validate();
        if (!resultValidation.isValid)
            return;
        this.verbsService.saveVerb(this.currentVerb).subscribe(result => {
            if (!result.success) {
                this.notificationService.notify({ messages: ["Saved failed!"], type: 'error' });
                return;
            }

            this.notificationService.notify({ messages: ["Saved successfully!"], type: 'success' });
            this.currentVerb.isFull = true;

            Object.assign(this.selectedVerb, this.currentVerb);
        });

        
    }

}
