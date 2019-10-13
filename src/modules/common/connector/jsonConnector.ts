import { Http } from "@angular/http";
import { IConnector } from "./iconnector";
import { PromiseFactory, Promise } from "../models/promise";
import "rxjs/add/operator/map";
import { ResponseModel } from "../models/responseModel";
import { HttpStatusCode, IoCNames } from "../models/enums";
import { IEventManager } from "../event/ieventManager";
import { ValidationResult } from "../models/ivalidationResult";


export class JsonConnector implements IConnector {
    public get(url: string): Promise {
        let def: Promise = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.get(url).map((response: any) => {
            return response.json();
        }).subscribe((response: any) => {
            self.processResponse(def, response);
        });
        return def;
    }
    
    public post(url: string, item: any): Promise {
        let self = this;
        let def: Promise = PromiseFactory.create();
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.post(url, item).map((response: any) => {
            return response.json();
        }).subscribe((response: any) => {
            self.processResponse(def, response);
        }, (err: any) => {
            def.reject(err._body.errors);
        });

        return def;
    }

    private processResponse(def: Promise, response: ResponseModel): Promise {
        if (!response || !response.hasOwnProperty("data")) {
            def.resolve(response);
            return;
        }
        if (response && response.statusCode == HttpStatusCode.OK) {
            def.resolve(response.data);
            return;
        }

        this.handleError(response.errors);
        def.reject(response.errors);
        return def;
    }

    private handleError(errors: Array<any>): void {
        errors = errors || [];
        let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
        errors.forEach((err: any) => {
            eventManager.publish(new ValidationResult(err.errorKey, false));
        });
    }
}