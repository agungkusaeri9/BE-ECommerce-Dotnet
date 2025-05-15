using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backend_dotnet.Helpers
{
    public static class ResponseFormatter
    {
        public static IActionResult Success(object? data = null, string? message = "Success", int code = 200, object? pagination = null)
        {
            dynamic response = new ExpandoObject();
            response.success = true;
            response.message = message;
            response.data = data;

            if (pagination != null)
            {
                response.pagination = pagination;
            }

            return code switch
            {
                200 => new OkObjectResult(response),
                201 => new ObjectResult(response) { StatusCode = 201 },
                _ => new ObjectResult(response) { StatusCode = code }
            };
        }

        public static IActionResult Error(string? message = "Something went wrong", object? errors = null, int code = 400)
        {
            dynamic response = new ExpandoObject();
            response.success = false;
            response.message = message;

            return new ObjectResult(response)
            {
                StatusCode = code
            };
        }

        // public static IActionResult ValidationError(object errors)
        // {
        //     return Error("Validation error", errors, 422);
        // }

        public static IActionResult BadRequest(string? message = "Bad Request", object? errors = null)
        {
            return Error(message, errors, 400);
        }

        public static IActionResult NotFound(string? message = "Resource not found")
        {
            var response = new
            {
                success = false,
                message
            };

            return new ObjectResult(response)
            {
                StatusCode = 404
            };
        }

        public static IActionResult ServerError(string? message = "Internal Server Error")
        {
            var response = new
            {
                success = false,
                message
            };

            return new ObjectResult(response)
            {
                StatusCode = 500
            };
        }

        public static IActionResult ValidationErrors(ActionContext context)
        {
            var errors = context.ModelState
                .Where(m => m.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            var response = new
            {
                success = false,
                message = "Validation failed",
                errors = errors
            };

            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
        }
    }
}
