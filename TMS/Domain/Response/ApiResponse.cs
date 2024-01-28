using Domain.Helpers;

namespace Domain.Response
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public object? Data { get; set; }
        public string Message { get; set; }
        public Pager? Pager { get; set; }

        public ApiResponse(bool success, string message, object? data, int statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        public ApiResponse(bool success, string message, int statusCode)
        {
            Success = success;
            Message = message;
            Data = null;
            StatusCode = statusCode;
        }

        public ApiResponse(bool success, string message, object? data, int statusCode, Pager? pager)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
            Pager = pager;
        }
    }
}
