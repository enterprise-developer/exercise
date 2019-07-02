import { IConnector } from "./iconnector";
import { Promise, PromiseFactory } from "../models/promise";
import { Http } from "@angular/http";
import { PromiseObservable } from "rxjs/observable/PromiseObservable";
import { HttpStatusCode, IoCNames } from "../models/enum";
import { IEventManager } from "../event/ieventManager";
import { IResponseData } from "../models/iResponseData";
import { IValidationError } from "../validation/ivalidationError";

export class JSONConnector implements IConnector {
    public get(url: string): Promise {
        let http: Http = window.ioc.resolve(Http);
        let promise: Promise = PromiseFactory.create();
        let self = this;
        http.get(url)
            .map(response => response.json())
            .subscribe((response: any) => {
                self.handleResponseData(response, promise);
            }, (errors: any) => {
                promise.reject(errors);
            });
        return promise;
    }

    public post(url: string, data: any): Promise {
        let http: Http = window.ioc.resolve(Http);
        let promise: Promise = PromiseFactory.create();
        let self = this;
        http.post(url, data)
            .map(response => response.json())
            .subscribe((response: any) => {
                self.handleResponseData(response, promise);
            }, (errors: any) => {
                promise.reject(errors);
            });
        return promise;
    }

    private handleResponseData(response: IResponseData, promise: Promise): void {
        if (!response || !response.hasOwnProperty("data")) {
            promise.resolve(response);
            return;
        }
        if (response && response.status == HttpStatusCode.OK) {
            promise.resolve(response.data);
            return;
        }
        this.handleErrors(response.errors);
        promise.reject();
    }

    private handleErrors(errors: Array<IValidationError>) {
        let eventManger: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        errors = errors || [];
        errors.forEach((error: IValidationError) => {
            eventManger.publish(error.errorKey, error.params);
        });
    }
}