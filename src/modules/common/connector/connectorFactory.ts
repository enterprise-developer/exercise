import {ConnectorType}  from "../enum";
import {IConnector} from "./iconnector";
import {JsonConnector} from "./jsonConnector";
export class ConnectorFactory{
    public static create(type: ConnectorType):IConnector{
        // url encoded
        // soap
        // json
        switch(type){
            case ConnectorType.Json:
                return new JsonConnector();
        }
    }
}