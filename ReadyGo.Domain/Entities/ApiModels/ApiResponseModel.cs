using ReadyGo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class ApiResponseModel
    {

        public ApiResponseModel(object result)
        {
            Result = result;
        }

        public ApiResponseModel(ApiStatus status, string error, ApiErrors errorType)
        {
            Status = status.ToString();
            Error = error;
            ErrorType = errorType.ToString();
        }
        public string Status { get; set; } = ApiStatus.Success.ToString();
        public string Error { get; set; } = null;
        public string ErrorType { get; set; } = null;
        public object Result { get; set; } = null;
    }
}
