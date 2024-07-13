using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				await HandleexceptionAsync(httpContext, ex);
			}
        }
		private static Task HandleexceptionAsync(HttpContext httpContext, Exception exception)
		{
			int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

			List<string> errors = new() 
			{ 
				$"Xeta Mesaji: {exception.Message}",
				$"Xeta Aciqlamasi: {exception.InnerException?.ToString()}"
			};
			return httpContext.Response.WriteAsync(new ExceptionModel
			{
				Errors=errors,
				StatusCode=statusCode
			}.ToString());
		}
		private static int GetStatusCode(Exception exception) =>
			exception switch
			{
				BadRequestException =>StatusCodes.Status400BadRequest,
				NotFoundException =>StatusCodes.Status400BadRequest,
				ValidationException =>StatusCodes.Status422UnprocessableEntity,
				_ =>StatusCodes.Status500InternalServerError
			};
    }
}
