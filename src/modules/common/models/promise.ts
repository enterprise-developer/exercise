import guidHelper from "../helpers/guidHelper";
import { PromiseStatus } from "../models/enums";

export class PromiseFactory {
    public static create(): Promise {
        return new Promise();
    }
}

export class Promise {
    private queue: Array<string> = [];
    private id: string;
    private status: PromiseStatus;
    private subscribeCallback: any;
    public data: any;
    private successCallback: any;

    constructor() {
        this.id = guidHelper.create();
    }

    public resolveAll(promise: Promise): Promise {
        let self = this;
        self.queue.push(promise.id);
        promise.subscribe((subPromise: Promise) => {
            self.checkAllComplete(subPromise);
        });
        return self;
    }

    public subscribe(callback: any): Promise {
        this.status = PromiseStatus.Subscribe;
        this.subscribeCallback = callback;
        return this;
    }

    private checkAllComplete(promise: Promise): void {
        this.queue = this.queue.removeItem(promise.id);
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
}