using ExamERP.Common.Attributes;
using ExamERP.Common.Enums;

namespace ExamERP.Business.Dto
{
    public class CreateProductRequest
    {
        [Required("business.addNewProduct.nameIsRequired")]
        [MinLength("business.addNewProduct.nameWasUnderMinLength",(int)ProductValidation.MinLength)]
        [MaxLength("business.addNewProduct.nameWasExcessMaxLength", (int)ProductValidation.MinLength)]
        public string Name { get; set; }

        [GEZero("business.addNewProduct.quantityShouldGreaterOrEqualThanZero")]
        public int Quantity { get; set; }

        [GEZero("business.addNewProduct.priceShouldGreaterOrEqualThanZero")]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
