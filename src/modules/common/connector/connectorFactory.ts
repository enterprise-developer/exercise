import { IConnector } from "./iconnector";
import {JsonConnector} from "./jsonConnector";
import { ConnectorType } from "../models/enums";

export class ConnectorFactory {
    public static create(type: ConnectorType): IConnector {
        switch (type) {
            case ConnectorType.Json:
                return new JsonConnector();
        }
    }
}