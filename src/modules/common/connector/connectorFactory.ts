import { IConnector } from "./iconnector";
import { ConnectorType } from "../models/enums";
import { JsonConnector } from "./jsonConnector";
export class ConnectorFactory {
    public static create(type: ConnectorType): IConnector {
        switch (type) {
            case ConnectorType.Json:
            default:
                return new JsonConnector();
        }
    }
}