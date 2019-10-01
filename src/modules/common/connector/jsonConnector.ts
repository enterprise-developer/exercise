import { IConnector } from "./iconnector";
import { Promise, PromiseFactory } from "../models/promise";

export class JsonConnector implements IConnector{
    public get(uri:string):Promise{
        let def:Promise=PromiseFactory.create();
        let http: Http = window.ioc.resolve(Http);
        http.get(uri)
        .map((response: any)=>{ return response.json();})
        .subscribe((json: any)=>{
            return def.resolve(json);
        });
        return def;
    }   
}