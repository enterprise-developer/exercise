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
    public data?: any;
    private successCallback: any;
    private failedCallback: any;
    private errors: Array<string>;
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

    private checkComplete(subPromise: Promise): void {
        this.queue = this.queue.removeItem(subPromise.id);
        if (this.queue.isEmpty()) {
            this.status = PromiseStatus.Success;
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
        if (this.status == PromiseStatus.Failed) {
            this.failedCallback(this.errors);
        }
    }

    public resolve(data?: any): Promise {

        this.data = data;
        this.status = this.status != PromiseStatus.Subscribe ? PromiseStatus.Success : this.status;
        this.processCallback();
        return this;
    }

    public then(callback: any): Promise {
        this.successCallback = callback;
        this.processCallback();
        return this;
    }

    public reject(errors?: Array<string>): Promise {
        this.status = PromiseStatus.Failed;
        this.errors = errors;
        this.processCallback();
        return this;
    }

}