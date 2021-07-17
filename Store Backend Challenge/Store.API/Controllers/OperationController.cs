﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class OperationController : BaseApiController
    {
        private readonly ILogger<OperationController> _logger;
        private readonly IProductServices _productServices;
        public OperationController(IProductServices productServices, ILogger<OperationController> logger)
        {
            _logger = logger;
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
            try
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
            catch (Exception ex)
            {
                _logger.LogError(" Status Code " + ApiStatusCode.InternalServerError + " get-product-info method. Exception " + ex.ToString());
                return Error<Product>(new ApiErrorCollection
                     { new ApiError
                      {
                        Code = ApiStatusCode.InternalServerError,
                        InternalMessage = ex.StackTrace,
                        Message = ex.Message
                        }
                 });
            }
        }


        [HttpGet("get-product-list")]
        public ApiReturn<List<Product>> GetProductList()
        {
            try
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

                return new ApiReturn<List<Product>>
                {
                    Data = productList,
                    Success = true,
                    Code = ApiStatusCode.Success,
                    Message = "Products are listed succesfully"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(" Status Code " + ApiStatusCode.InternalServerError + " get-product-list method. Exception " + ex.ToString());
                return Error<List<Product>>(new ApiErrorCollection
                     { new ApiError
                      {
                        Code = ApiStatusCode.InternalServerError,
                        InternalMessage = ex.StackTrace,
                        Message = ex.Message
                        }
                 });
            }
        }

        [HttpPost("insert-product")]
        public ApiReturn<Product> InsertProduct(Product productRequest)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(" Status Code " + ApiStatusCode.InternalServerError + " insert-product method. Exception " + ex.ToString());
                return Error<Product>(new ApiErrorCollection
                     { new ApiError
                      {
                        Code = ApiStatusCode.InternalServerError,
                        InternalMessage = ex.StackTrace,
                        Message = ex.Message
                        }
                 });
            }
        }
    }
}
