using TestERP.Common.Attributes;
using TestERP.Inventory.Enums;

namespace TestERP.Inventory.Dto
{
    public class CreateProductRequest
    {
        [Required("inventory.addNewProduct.nameIsRequired")]
        [MinLength("inventory.addNewProduct.nameWasUnderMinLength",(int) ProductValidation.MinLength)]
        [MaxLength("inventory.addNewProduct.nameWasExcessMaxLength", (int) ProductValidation.MaxLength)]
        public string Name { get; set; }

        [GeZero("inventory.addNewProduct.quantityShouldGreaterOrEqualThanZero")]
        public int Quantity { get; set; }

        [GeZero("inventory.addNewProduct.priceShouldGreaterOrEqualThanZero")]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
