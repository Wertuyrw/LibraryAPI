﻿using Application.DTO;
using Application.Exceptions;
using System.Net;
using System.Security.Authentication;

namespace LibraryAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (ExistsException e)
            {
                await HandleExceptionAsync(context,
                    e.Message,
                    HttpStatusCode.BadRequest,
                    e.Message);
            }
            catch (NotFoundException e)
            {
                await HandleExceptionAsync(context,
                    e.Message,
                    HttpStatusCode.NotFound,
                    e.Message);
            }
            catch (AuthenticationException e)
            {
                await HandleExceptionAsync(context,
                    e.Message,
                    HttpStatusCode.Unauthorized,
                    e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                _logger.LogTrace(e.InnerException.ToString());

                await HandleExceptionAsync(context,
                    e.Message,
                    HttpStatusCode.InternalServerError,
                    e.Message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exMsg, HttpStatusCode httpStatusCode,
            string message)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            var errorDto = new ErrorDTO
            {
                StatusCode = (int)httpStatusCode,
                Message = message
            };

            await response.WriteAsJsonAsync(errorDto);
        }
    }
}
