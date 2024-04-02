using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TaskManager.Domain.Exceptions;


//implementalo asi = throw new BussineesException(string del mensaje)
// o throw new ServerException(string del mensaje)

namespace TaskManager.Infraestructure.Filters
{
    public class GlobalExceptions : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
             var exception = context.Exception;
            
            if(context.Exception.GetType() == typeof(BussinessException))
            {
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message

                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true; 
            }

            if(context.Exception.GetType() ==  typeof(ServerException))
            {
                var validation = new
                {
                    Status = 500,
                    Title = "Internal Error",
                    Detail = exception.Message
                };
                var json = new
                {
                    errors = new[] { validation }
                };
                context.Result = new ObjectResult(json); 
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;

            }
        }
    }
}
