import guidHelper from "../helpers/guid";
import { PromiseStatus } from "./enums";
export class PromiseFactory {
    public static create(): Promise {
        return new Promise();
    }
}
export class Promise {
    private queue: Array<string> = [];
    public id: string;
    private subscribeCallback: any;
    private status: PromiseStatus;
    private data?: any;
    private successCallback: any;
    constructor() {
        this.id = guidHelper.newGuid();
    }
    public resolveAll(subPromise: Promise): Promise {
        let self = this;
        self.queue.push(subPromise.id);
        subPromise.subscribe((subPromise: Promise) => {
            self.checkComplete(subPromise);
        });
        return self;
    }

    public subscribe(callback: any): Promise {
        this.subscribeCallback = callback;
        return this;
    }

    private checkComplete(subPromise: Promise): void {
        this.queue = this.queue.removeItem(subPromise.id);
        if (this.queue.isEmpty()) {
            this.status = PromiseStatus.Subscribe;
            this.processCallback();
        }
    }

    private processCallback() {
        if (this.status == PromiseStatus.Subscribe && !!this.subscribeCallback) {
            this.subscribeCallback(this);
        }

        if (this.status == PromiseStatus.Success && !!this.successCallback) {
            this.successCallback(this.data);
        }
    }

    public resolve(data?: any): Promise {
        this.data = data;
        this.status = PromiseStatus.Success;
        this.processCallback();
        return this;
    }

    public then(callback: any): Promise {
        this.successCallback = callback;
        this.processCallback();
        return this;
    }
}