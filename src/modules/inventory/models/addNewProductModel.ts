import { BaseModel, required, minLength, maxLength, geZero, ProductValidation } from "@app/common";


export class AddNewProductModel extends BaseModel {
    @required("inventory.addNewProduct.nameIsRequired")
    @minLength("inventory.addNewProduct.nameWasUnderMinLength", ProductValidation.MinLength)
    @maxLength("inventory.addNewProduct.nameWasExcessMaxLength", ProductValidation.MaxLength)
    public name: string;

    @required("inventory.addNewProduct.quantityIsRequired")
    @geZero("inventory.addNewProduct.quantityShouldGreaterOrEqualThanZero")
    public quantity: number;

    @required("inventory.addNewProduct.priceIsRequired")
    @geZero("inventory.addNewProduct.priceShouldGreaterOrEqualThanZero")
    public price: number;

    public description: string;
}