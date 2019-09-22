import { required, minLength, ProductValidation, maxLength, geZero } from "@app/common";
import { BaseModel } from "@app/common";
export class AddNewProductModel extends BaseModel {
    @required("business.addNewProduct.nameIsRequired")
    @minLength("business.addNewProduct.nameWasUnderMinLength", ProductValidation.MinLength)
    @maxLength("business.addNewProduct.nameWasExcessMaxLength", ProductValidation.MaxLength)
    name: string;

    @geZero("business.addNewProduct.quantityShouldGreaterOrEqualThanZero")
    quatity: number;


    @geZero("business.addNewProduct.priceShouldGreaterOrEqualThanZero")
    price: number;

    description: string;
}