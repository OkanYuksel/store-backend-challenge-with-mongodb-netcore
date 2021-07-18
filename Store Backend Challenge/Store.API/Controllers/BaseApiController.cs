using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_Backend_Challenge.Controllers
{
    public class BaseApiController : ControllerBase
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        private const string BadRequestMessage = "Bad Request.";

        protected ApiReturn<T> Error<T>(string message = BadRequestMessage, string internalMessage = default(string), ApiStatusCode code = ApiStatusCode.BadRequest)
        {
            return Error<T>(null, message, internalMessage, code);
        }

        protected ApiReturn<T> Error<T>(ApiErrorCollection errors, string message = BadRequestMessage, string internalMessage = default(string), ApiStatusCode code = ApiStatusCode.BadRequest)
        {
            return new ApiReturn<T>
            {
                Code = code,
                Message = message,
                Success = false,
                Errors = errors
            };
        }

        protected ApiReturn<T> InternalError<T>(ApiErrorCollection errors, string message = "There is something wrong.", string internalMessage = default(string), ApiStatusCode code = ApiStatusCode.InternalServerError)
        {
            return new ApiReturn<T>
            {
                Code = code,
                Message = message,
                Success = false,
                Errors = errors
            };
        }

        protected ApiReturn<T> Invalid<T>(string message = "Invalid action.", string internalMessage = default(string), ApiStatusCode code = ApiStatusCode.BadRequest)
        {
            return new ApiReturn<T>
            {
                Code = code,
                Message = message,
                InternalMessage = internalMessage,
                Success = false
            };
        }

        protected ApiReturn<T> NotFound<T>(ApiErrorCollection errors, string message = "Not Found.", string internalMessage = default(string), ApiStatusCode code = ApiStatusCode.NotFound)
        {
            return new ApiReturn<T>
            {
                Code = code,
                Message = message,
                Success = false,
                Errors = errors
            };
        }

        protected ApiReturn<T> Success<T>(T data, string message = "Success")
        {
            return new ApiReturn<T>
            {
                Code = ApiStatusCode.Success,
                Message = message,
                Success = true,
                Data = data
            };
        }

    }
}
