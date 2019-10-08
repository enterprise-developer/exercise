import { IConnector } from "./iconnector";
import { PromiseFactory, Promise } from "../models/promise";
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
import { IResponseModel, HttpStatusCode } from "../models/enums";
export class JsonConnector implements IConnector {
    public get(url: string): Promise {
        let def: Promise = PromiseFactory.create();
        let http: Http = window.ioc.resolve(Http);
        let self = this;
        http.get(url).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            self.processResponse(def, data);
        });
        return def;
    }
    private processResponse(def: Promise, response: IResponseModel) {
        if (!response || !response.hasOwnProperty("data")) {
            def.resolve(response);
            return;
        }
        if (response && response.statusCode == HttpStatusCode.OK) {
            def.resolve(response.data);
            return;
        }
    }
}