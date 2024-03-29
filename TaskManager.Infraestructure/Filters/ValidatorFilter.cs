
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManager.Infraestructure.Filters
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        //ejecutar antes de llegar al controller
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid) {

                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            await next(); 
        }
    }
}
