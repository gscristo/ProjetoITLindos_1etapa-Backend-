
namespace Api.Model.Product
{
    public class CreateProductRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Value { get; set; }

        public static implicit operator Core.Product.Model.Product(CreateProductRequest createProductRequest)
        {
            if (createProductRequest == null)
                return null;

            return new Core.Product.Model.Product
            {
             
                Code = createProductRequest.Code,
                Name = createProductRequest.Name,
                Description = createProductRequest.Description,
                Unit = createProductRequest.Unit,
                Value = createProductRequest.Value,
                
            };
        }
    }
}
