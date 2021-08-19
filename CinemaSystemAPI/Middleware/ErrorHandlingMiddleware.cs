using CinemaSystemAPI.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaSystemAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(BadRequestException badRequestException)
            {
                logger.LogError(badRequestException, badRequestException.Message);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch(IsNullOrEmptyException isNullOrEmptyException)
            {
                logger.LogError(isNullOrEmptyException, isNullOrEmptyException.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(isNullOrEmptyException.Message);
            }
            catch(NotFoundException notFoundException)
            {
                logger.LogError(notFoundException, notFoundException.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch(SqlException sqlException)
            {
                logger.LogError(sqlException, sqlException.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(sqlException.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
