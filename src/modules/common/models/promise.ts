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
    private status: PromiseStatus;
    private subscribeCallback: any;
    private successCallback: any;
    public data: any;
    public errors: any;
    private errorCallback: any;
    constructor() {
        this.id = guidHelper.create();
    }

    public resolveAll(subPromise: Promise): Promise {
        let self = this;
        self.queue.push(subPromise.id);
        subPromise.subscribe((subPro: Promise) => {
            self.checkComplete(subPro);
        });
        return this;
    }

    public subscribe(callback?: any): Promise {
        this.status = PromiseStatus.Subscribe;
        this.subscribeCallback = callback;
        return this;
    }

    private checkComplete(subPro: Promise): void {
        this.queue = this.queue.removeItem(subPro.id);
        if (this.queue.isEmpty()) {
            this.status = PromiseStatus.Success;
            this.processCallback();
        }
    }

    private processCallback(): void {
        if (this.status == PromiseStatus.Subscribe && !!this.subscribeCallback) {
            this.subscribeCallback(this);
        }

        if (this.status == PromiseStatus.Success && !!this.successCallback) {
            this.successCallback(this.data);
        }

        if (this.status == PromiseStatus.Failed && !!this.errorCallback) {
            this.errorCallback(this.errors);
        }
    }

    public reject(errors?: Array<any>): Promise {
        this.status = PromiseStatus.Failed;
        this.errors = errors;
        this.processCallback();
        return this;
    }

    public resolve(data?: any): Promise {
        this.status = this.status != PromiseStatus.Subscribe ? PromiseStatus.Success : this.status;
        this.data = data;
        this.processCallback();
        return this;
    }

    public then(callback: any): Promise {
        this.successCallback = callback;
        this.processCallback();
        return this;
    }
}