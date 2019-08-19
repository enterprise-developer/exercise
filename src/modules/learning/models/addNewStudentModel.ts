import { required } from "../../common/components/decorators/required";
export class AddNewStudentModel {
    @required("abc")
    public firstName: string;
}