using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store_Backend_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IProductServices _productServices;
        public OperationController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public string OperationControllerInfo()
        {
            return "This controller developed for 'Store Backend Challange' project.";
        }

        [HttpGet("get-product-info")]
        public ApiReturn<Product> GetProductInfo(string id)
        {
            Product product = _productServices.GetProduct(id);

            if (product == null)
            {
                return new ApiReturn<Product>
                {
                    Success = false,
                    Code = ApiStatusCode.NotFound,
                    Message = "Product not found"
                };
            }

            return new ApiReturn<Product>
            {
                Data = product,
                Success = true,
                Code = ApiStatusCode.Success,
                Message = "Product is listed succesfully"
            };

        }

        [HttpGet("get-product-list")]
        public ApiReturn<List<Product>> GetProductList()
        {
            List<Product> productList = _productServices.GetProducts();

            if (productList.Count == 0)
            {
                return new ApiReturn<List<Product>>
                {
                    Success = false,
                    Code = ApiStatusCode.NotFound,
                    Message = "No products found"
                };
            }

            var resp = new ApiReturn<List<Product>>
            {
                Data = productList,
                Success = true,
                Code = ApiStatusCode.Success,
                Message = "Products are listed succesfully"
            };

            var address = JsonSerializer.Serialize(resp);

            return resp;
        }

        [HttpPost("insert-product")]
        public ApiReturn<Product> InsertProduct(Product productRequest)
        {
            Product product = _productServices.AddProduct(productRequest);

            if (product == null)
            {
                return new ApiReturn<Product>
                {
                    Success = false,
                    Code = ApiStatusCode.NotFound,
                    Message = "Product not found"
                };
            }

            return new ApiReturn<Product>
            {
                Data = product,
                Success = true,
                Code = ApiStatusCode.Success,
                Message = "Product is listed succesfully"
            };
        }

    }


}
