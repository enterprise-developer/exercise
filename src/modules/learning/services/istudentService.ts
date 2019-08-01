import { Promise } from "@angular/common";
export interface IStudentService {
    getStudents(): Promise;
}