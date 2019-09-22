import { ConnectorType } from "../models/enums";
import { JsonConnector } from "./jsonConnector";
export class ConnectorFactory {
    public static create(type: string): any {
        switch (type) {
            case ConnectorType.Json:
            default:
                return new JsonConnector();
        }
    }
}