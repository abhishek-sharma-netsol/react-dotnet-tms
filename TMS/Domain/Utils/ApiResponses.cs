using Domain.Helpers;
using Domain.Response;
using Microsoft.AspNetCore.Http;

namespace Domain.Utils
{
    public static class ApiResponses
    {
        public static ApiResponse RequestorDoesNotExist(string requestor)
        {
            return new ApiResponse(false, $"{requestor} does not exists.", StatusCodes.Status401Unauthorized);
        }

        public static ApiResponse ResourceDoesNotExist(string resource)
        {
            return new ApiResponse(false, $"{resource} does not exist.", StatusCodes.Status404NotFound);
        }

        public static ApiResponse Success(string message, object? data = null, Pager? pagingInfo = null)
        {
            return new ApiResponse(true, message, data, StatusCodes.Status200OK, pagingInfo);
        }

        public static ApiResponse Conflict(string message = "Resource already exists.")
        {
            return new ApiResponse(false, message, StatusCodes.Status409Conflict);
        }

        public static ApiResponse InternalServerError(string message = "Internal server error.")
        {
            return new ApiResponse(false, message, StatusCodes.Status500InternalServerError);
        }

        public static ApiResponse Forbidden()
        {
            return new ApiResponse(false, "You are not allowed to perform this operation", StatusCodes.Status403Forbidden);
        }

        public static ApiResponse BadRequest(string message)
        {
            return new ApiResponse(false, message, StatusCodes.Status400BadRequest);
        }
    }
}
