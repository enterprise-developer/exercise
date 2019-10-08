import guidHelper from "../helpers/guidHelper";
import { PromiseStatus } from "./enums";
export class Promise {
    private queue: Array<string>;
    private id: string;
    private status: PromiseStatus;
    private subscribeCallback: any;
    private successCallback: any;
    public data: any;
    constructor() {
        this.id = guidHelper.create();
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
        this.status = PromiseStatus.Subscribe;
        this.subscribeCallback = callback;
        return this;
    }

    public resolve(data?: any): Promise {
        this.data = data;
        this.status = this.status != PromiseStatus.Subscribe ? PromiseStatus.Success : this.status;
        this.processCallback();
        return this;
    }
    public then(callBack: any): Promise {
        this.successCallback = callBack;
        this.processCallback();
        return this;
    }
    private checkComplete(subPromise: Promise): void {
        this.queue = this.queue.removeItem(subPromise.id);
        if (this.queue.isEmpty()) {
            this.status = PromiseStatus.Success;
            this.processCallback();
        }
    }
    private processCallback() {
        if (this.status == PromiseStatus.Success && !!this.successCallback) {
            this.successCallback();
        }
        if (this.status == PromiseStatus.Subscribe && !!this.subscribeCallback) {
            this.subscribeCallback();
        }
    }
}

export class PromiseFactory {
    public static create(): Promise {
        return new Promise();
    }
}