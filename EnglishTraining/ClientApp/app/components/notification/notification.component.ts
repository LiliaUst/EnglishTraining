import { Component, ElementRef, trigger, transition, style, animate  } from "@angular/core";
import "rxjs/Rx";
import { Subscription } from "rxjs/Subscription";
import { Subject } from "rxjs/Subject";
import { NotificationService, NotificationItem } from "../../services/notification.service";

@Component({
    selector: "app-notification",
    templateUrl: "./notification.component.html",
    styleUrls: ["./notification.component.css"],
    animations: [
        trigger(
            'animatedNotification', [
                transition(':enter', [
                    style({ opacity: 0 }),
                    animate('200ms', style({ opacity : 1 }))
                ]),
                transition(':leave', [
                    style({ opacity: 1 }),
                    animate('200ms', style({ opacity : 0 }))
                ])
            ]
        )
    ],
    host: {
        '(document:click)':'onClick($event)'
    }
})
export class NotificationComponent {
    protected isCanOutsideClick: boolean = false;
    protected animateOutTimer: any;
    constructor(private notificationService: NotificationService, private _eref: ElementRef) {
    }

    onClick(event: any) {
        let currNotificationItem = this.currentNotificationItem();
        if (!this._eref.nativeElement.contains(event.target) && this.notificationService.notificationItems.length > 0 && this.isCanOutsideClick === true)
            this.notificationService.clearAll();
        if (currNotificationItem !== null) {
            if (this._eref.nativeElement.contains(event.target) && currNotificationItem.closeOnClick == true) {
                this.notificationService.clearAll();
            }
        }
        this.checkOutsideClick();
    }
    animateIn() {
        this.isCanOutsideClick = true;
        let currNotificationItem = this.currentNotificationItem();
        clearTimeout(this.animateOutTimer);
        if (currNotificationItem !== null && currNotificationItem !== undefined) {
            this.animateOutTimer = setTimeout(() => {
                this.animateOut();
            }, (currNotificationItem.displayTime + 200));
        }
        else {
            this.animateOut();
        }
    } 
    animateOut() {
        this.isCanOutsideClick = false;
    }
    checkOutsideClick() {
        if (this.notificationService.notificationItems.length > 0) {
            this.isCanOutsideClick = true;
        }
        else {
            this.isCanOutsideClick = false;
        }
    }
    currentNotificationItem() {
        let notificationElements = this._eref.nativeElement.querySelectorAll(".notification-content");
        let timestamp = (notificationElements.length > 0) ? notificationElements[0].getAttribute("data-timestamp") : null;
        let currNotificationItem = null;
        if (timestamp) {
            currNotificationItem = this.notificationService.get(timestamp);
        }
        return currNotificationItem;
    }
}