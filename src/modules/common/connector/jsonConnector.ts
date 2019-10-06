import { Http } from "@angular/http";
import { IConnector } from "./iconnector";
import { PromiseFactory, Promise } from "../models/promise";
import "rxjs/add/operator/map";
import { ResponseModel } from "../models/responseModel";


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

    private processResponse(def: Promise, response: ResponseModel): Promise {
        if (!!response && response.data) {
            def.resolve(response.data);
        }
        else if (!!response) {
            def.resolve(response);
        }

        return def;
    }
}