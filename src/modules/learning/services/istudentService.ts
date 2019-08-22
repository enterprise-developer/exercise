import { Promise } from "@app/common";
export interface IStudentService {
    getStudents(): Promise;
    addNewStudent(item: any): Promise;
}