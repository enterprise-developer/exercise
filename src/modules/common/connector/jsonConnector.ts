import { IConnector } from "./iconnector";
import { PromiseFactory, Promise } from "../models/promise";
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import { ResponseModel } from "../models/responseModel";
import { HttpStatusCode, IoCNames } from "../models/enums";
import { ValidationResult } from "../models/ivalidationResult";
import { IEventManager } from "../services/ieventManager";
export class JsonConnector implements IConnector {
    public get(url: string): Promise {
        let def = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.get(url).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }

    public post(url: string, item: any): Promise {
        let def = PromiseFactory.create();
        let self = this;
        let httpClient: Http = window.ioc.resolve(Http);
        let newItemData: any = this.toJson(item);
        httpClient.post(url, newItemData).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        }, (error: ResponseModel) => {
            self.processResponse(def, error);
        });
        return def;
    }

    private toJson(item: any): any {
        let newItemData: any = {};
        for (let prop in item) {
            if (prop.startsWith("_")) {
                let newProp = prop.substr(1);
                newItemData[newProp] = item[prop];
            } else {
                newItemData[prop] = item[prop];
            }
        }
        return newItemData;
    }

    private processResponse(def: Promise, response: ResponseModel) {
        if (response.errors != null) {
            let eventManager: IEventManager = window.ioc.resolve(IoCNames.IEventManager);
            response.errors.forEach((error: any) => {
                eventManager.publish(new ValidationResult(error.errorKey, false));
            });
            def.reject(response.errors);
            return;
        }
        if (response.errors == null && response.data != null) {
            def.resolve(response.data);
            return;
        }
        if (response.errors == null && response.data == null) {
            def.resolve(response);
        }
    }


}