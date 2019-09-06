import { Promise } from "@app/common";
import { AddNewStudentModel } from "../models/addNewStudentModel";
export interface IStudentService {
    getStudents(): Promise;
    addNewStudent(item: AddNewStudentModel): Promise;
}