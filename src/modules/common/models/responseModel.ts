import { HttpStatusCode } from "./enums";
export class ResponseModel {
    errors: Array<string>;
    data: any;
    statusCode: HttpStatusCode
}