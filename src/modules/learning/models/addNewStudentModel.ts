import { required, minLength, maxLength } from "@app/common";
import { StudentValidationRules } from "../constant";
import { BaseModel } from "@app/common";
export class AddNewStudentModel extends BaseModel {
    @required("learning.addNewStudent.firstNameIsRequired")
    @minLength("learning.addNewStudent.firstNameUnderMinLength", StudentValidationRules.MinLength)
    @maxLength("learning.addNewStudent.firstNameExcessMaxLength", StudentValidationRules.MaxLength)
    public firstName: string;

    @required("learning.addNewStudent.lastNameIsRequired")
    @minLength("learning.addNewStudent.lastNameUnderMinLength", StudentValidationRules.MinLength)
    @maxLength("learning.addNewStudent.lastNameExcessMaxLength", StudentValidationRules.MaxLength)
    public lastName: string;

    @required("learning.addNewStudent.userNameIsRequired")
    @minLength("learning.addNewStudent.userNameUnderMinLength", StudentValidationRules.MinLength)
    @maxLength("learning.addNewStudent.userNameExcessMaxLength", StudentValidationRules.MaxLength)
    public userName: string;
}