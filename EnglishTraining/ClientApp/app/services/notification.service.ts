import { Injectable } from '@angular/core';

@Injectable()
export class NotificationService {
    notificationItems: Array<NotificationItem> = [];
    timer: any;

    constructor() {}

    notify({ messages, type, displayTime, clearAll, closeOnClick, width, position }:
        { messages: Array<string>, type?: string, displayTime?: number, clearAll?: boolean, closeOnClick?: boolean, width?: number, position?: string }) {

        if (messages.length > 0) {
            let notificationItem = new NotificationItem(messages, type, displayTime, clearAll, closeOnClick, width, position);
            if (notificationItem.clearAll == true)
                this.clearAll();

            this.notificationItems.push(notificationItem);
            clearTimeout(this.timer);
            this.timer = setTimeout(() => {
                this.clear(notificationItem.timestamp);
            }, notificationItem.displayTime);
        }
    }

    get(timestamp: string = "") {
        let notificationItem: any;
        if (timestamp !== "") {
            notificationItem = this.notificationItems.filter(function (item) { return item.timestamp == timestamp });
        }
        return notificationItem[0];
    }

    clear(timestamp: string = "") {
        let notificationItem;
        if (timestamp !== "") {
            notificationItem = this.get(timestamp);
            if (notificationItem !== typeof (Array))
                this.notificationItems.splice(this.notificationItems.indexOf(notificationItem), 1);
            else
                this.clearAll();
        }
    }

    clearByPosition(position: string) {
        let notificationItems: any;
        if (position === "top" || position === "bottom") {
            notificationItems = this.notificationItems.filter((item) => item.position == position);
        }
        notificationItems.forEach((value: any) => this.clear(value.timestamp));
    }

    clearAll() {
        this.notificationItems = [];
    }
}

export class NotificationItem {
    messages: Array<string> = [];
    type: string = "info"; //"info", "warning", "error", "success"
    displayTime?: number = 4000;
    clearAll: boolean = true;
    closeOnClick: boolean = true;
    width: number = 400;
    position: string = "top"; //"bottom", "top"
    timestamp: string;

    public constructor(
        messages: Array<string>,
        type?: string,
        displayTime?: number,
        clearAll?: boolean,
        closeOnClick?: boolean,
        width?: number,
        position?: string
    ) {
        this.messages = (messages !== undefined) ? messages : this.messages;
        this.type = (type !== undefined) ? type : this.type;
        this.displayTime = (displayTime !== undefined) ? displayTime : this.displayTime;
        this.closeOnClick = (closeOnClick !== undefined) ? closeOnClick : this.closeOnClick;
        this.clearAll = (clearAll !== undefined) ? clearAll : this.clearAll;
        this.width = (width !== undefined) ? width : this.width;
        this.position = (position !== undefined) ? position : this.position;
        this.timestamp = new Date().getTime().toString();
    }
}