using AcademiaIntegrationTestAndMock.Common.DTOs;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaIntegrationTestAndMock.Common.Extensions
{
    public static class ControllerExtensions
    {
        private static ErrorResponse BuildMessage(string message) => new() { Message = message };

        public static IActionResult ActionResultFrom<TData>(this ControllerBase controller, ErrorOr<TData> data)
        {

            if (!data.IsError)
            {
                return controller.Ok(data);
            }

            object objMessage = BuildMessage(data.FirstError.Description);

            return data.FirstError.Type switch
            {
                ErrorType.Validation => controller.BadRequest(objMessage),
                ErrorType.Unauthorized => controller.Unauthorized(objMessage),
                ErrorType.NotFound => controller.NotFound(objMessage),
                _ => controller.StatusCode(500, objMessage)
            };
        }
    }
}
