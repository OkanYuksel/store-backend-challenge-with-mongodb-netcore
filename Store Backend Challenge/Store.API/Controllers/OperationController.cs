using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Core;
using Store.Core.MedCore.Commands;
using Store.Core.MedCore.Queries;
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
        private readonly IMediator _mediator;
        public OperationController(IMediator mediator, IProductServices productServices, ILogger<OperationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _productServices = productServices;
        }

        [HttpGet]
        public string OperationControllerInfo()
        {
            return "This controller developed for 'Store Backend Challange' project.";
        }

        [HttpGet("get-product-info")]
        public async Task<ApiReturn<Product>> GetProductInfoAsync(string id)
        {
            try
            {
                GetProductInfoByIdQuery getProductInfoByIdQuery = new GetProductInfoByIdQuery { Id = id };
                var product = await _mediator.Send(getProductInfoByIdQuery);

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
        public async Task<ApiReturn<List<Product>>> GetProductListAsync()
        {
            try
            {
                var query = new GetAllProductsQuery();

                List<Product> productList = await _mediator.Send(query);

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
        public async Task<ApiReturn<Product>> InsertProductAsync(Product productRequest)
        {
            try
            {
                InsertProductCommand getProductInfoByIdQuery = new InsertProductCommand { Product = productRequest };
                var product = await _mediator.Send(getProductInfoByIdQuery);

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
