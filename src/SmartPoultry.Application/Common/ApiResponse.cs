using System;
using System.Collections.Generic;
using System.Net;

namespace SmartPoultry.Common
{
    public class ApiResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Request completed successfully.";
        public dynamic Data { get; set; } = null;
        public List<string> Errors { get; set; }
        public HttpStatusCode SuccessCode { get; set; } = HttpStatusCode.OK;

        public static ApiResponse SuccessResponse(dynamic data, string message = null, HttpStatusCode successCode = HttpStatusCode.OK)
        {
            return new ApiResponse
            {
                Success = true,
                Data = data,
                Message = message ?? "Success",
                SuccessCode = successCode
            };
        }

        public static ApiResponse FailureResponse(string message, List<string> errors = null, HttpStatusCode successCode = HttpStatusCode.BadRequest)
        {
            return new ApiResponse
            {
                Success = false,
                Message = message,
                Errors = errors,
                SuccessCode = successCode
            };
        }
    }

}
