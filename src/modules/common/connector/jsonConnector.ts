import { IConnector } from "./iconnector";
import { PromiseFactory, Promise } from "../models/promise";
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';
export class JsonConnector implements IConnector {
    public get(url: string): Promise {
        let def = PromiseFactory.create();
        let httpClient: Http = window.ioc.resolve(Http);
        httpClient.get(url).map((response: any) => {
            return response.json();
        }).subscribe((data: any) => {
            def.resolve(data);
        });
        return def;
    }
}