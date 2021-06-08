using Api.Model;
using Api.Model.Product;
using Core.Infrastructure.Exceptions;
using Core.Product.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetProductById _getProductById;
        private readonly IDeleteProduct _deleteProduct;
        private readonly IDeleteProductByCode _deleteProductByCode;
        private readonly IUpdateProduct _updateProduct;
        private readonly IGetAllProduct _getAllProduct;
        private readonly ICreateProduct _createProduct;
        private readonly IGetProductByName _getProductByName;
        private readonly IGetProductByCode _getProductByCode;

        public ProductController(IGetProductById getProductById,
                                  IDeleteProduct deleteProduct,
                                  IDeleteProductByCode deleteProductByCode,
                                  IUpdateProduct updateProduct,
                                  IGetAllProduct getAllProduct,
                                  ICreateProduct createProduct,
                                  IGetProductByName getProductByName,
                                  IGetProductByCode getProductByCode)
        {
            _getProductById = getProductById;
            _deleteProduct = deleteProduct;
            _deleteProductByCode = deleteProductByCode;
            _updateProduct = updateProduct;
            _getAllProduct = getAllProduct;
            _createProduct = createProduct;
            _getProductByName = getProductByName;
            _getProductByCode = getProductByCode;

        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> Get([FromBody] PaginationRequest paginationRequest)
        {
            try
            {
                var model = await _getAllProduct.Execute(paginationRequest.PageSize, paginationRequest.PageIndex, paginationRequest.Sort, paginationRequest.Direction);

                return Ok(Result.Create(model, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetId(Guid productId)
        {
            try
            {
                var result = await _getProductById.Execute(productId);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("filter/{productByName}")]
        public async Task<IActionResult> GetName(string productByName)
        {
            try
            {
                var result = await _getProductByName.Execute(productByName);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("filter/1/{productByCode}")]
        public async Task<IActionResult> GetCode(string productByCode)
        {
            try
            {
                var result = await _getProductByCode.Execute(productByCode);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductRequest updateProductRequest)
        {
            try
            {
                var result = await _updateProduct.Execute(updateProductRequest);

                return Ok(Result.Create(updateProductRequest, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ApiDomainException domainException)
            {
                return BadRequest(Result.Create(domainException.Errors, HttpStatusCode.BadRequest, "Erro ao executar a operação"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest createProductRequest)
        {
            try
            {
                var result = await _createProduct.Execute(createProductRequest);

                return Ok(Result.Create(result, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ApiDomainException domainException)
            {
                return BadRequest(Result.Create(domainException.Errors, HttpStatusCode.BadRequest, "Ops! Algo de errado aconteceu, verifique se o código do produto ja existe ou se a unidade é válida."));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{productId}")]
        public IActionResult Delete(Guid productId)
        {
            try
            {
                _deleteProduct.Execute(productId);

                return Ok(Result.Create(productId, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpDelete]
        [Route("filter/{productCode}")]
        public IActionResult DeleteByCode(string productCode)
        {
            try
            {
                _deleteProductByCode.Execute(productCode);

                return Ok(Result.Create(productCode, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
