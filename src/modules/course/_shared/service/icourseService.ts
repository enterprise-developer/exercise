import { Promise } from "@app/common";

export interface ICourseService{
    getCourses():Promise;
    createCourse(course:any):Promise;
}