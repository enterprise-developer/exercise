import { HttpStatusCode } from "./enum";
import { IValidationError } from "../validation/ivalidationError";

export interface IResponseData{
    data:any,
    status:HttpStatusCode,
    errors:Array<IValidationError>
}