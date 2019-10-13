import { HttpStatusCode } from "./enums";

export class ResponseModel {
    data?: any;
    statusCode: HttpStatusCode;
    errors: Array<any>;
}