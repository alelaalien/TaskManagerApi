using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Exceptions;

namespace TaskManager.Infraestructure.Filters
{
    public class GlobalExceptions : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(BussinessException))
            {
                var exception = context.Exception;
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
              

            }
        }
    }
}
