using System;
using System.Collections.Generic;

namespace Core.Product.Model
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }

        public static implicit operator Product(DataAccess.Entities.Product model)
        {
            if (model == null)
                return null;

            return new Product
            {
                ProductId = model.ProductId,
                Code = model.Code,
                Name = model.Name,
                Description = model.Description,
                Unit = model.Unit,
                Value = model.Value

            };
        }


        public static implicit operator DataAccess.Entities.Product(Product product)
        {
            if (product == null)
                return null;

            return new DataAccess.Entities.Product
            {
                ProductId = product.ProductId,
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Unit = product.Unit,
                Value = product.Value
            };
        }
    }
}
