using System;

namespace Api.Model.Product
{
    public class UpdateProductRequest
    {

        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }

        public static implicit operator Core.Product.Model.Product(UpdateProductRequest updateProductRequest)
        {
            if (updateProductRequest == null)
                return null;

            return new Core.Product.Model.Product
            {

                ProductId = updateProductRequest.ProductId,
                Code = updateProductRequest.Code,
                Name = updateProductRequest.Name,
                Description = updateProductRequest.Description,
                Unit = updateProductRequest.Unit,
                Value = updateProductRequest.Value,

            };
        }
    }
}