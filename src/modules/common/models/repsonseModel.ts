import { HttpStatusCode } from "../models/enums";
export class RepsonseModel {
    errors: Array<any>;
    statusCode: HttpStatusCode;
    data: any;
}