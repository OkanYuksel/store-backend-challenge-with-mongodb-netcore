using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Core;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string OperationControllerInfo(string id)
        {
            return "This controller developed for 'Store Backend Challange' project.";
        }


        [HttpGet("get-product-info")]
        public Product GetProductInfo(string id)
        {
            Product product = _productServices.GetProduct(id);
            return product;
        }

        [HttpGet("get-product-list")]
        public List<Product> GetProductList()
        {
            List<Product> productList = _productServices.GetProducts();
            return productList;
        }

        [HttpPost("insert-product")]
        public Product InsertProduct(Product productRequest)
        {
            _productServices.AddProduct(productRequest);
            return productRequest;
        }

    }


}
