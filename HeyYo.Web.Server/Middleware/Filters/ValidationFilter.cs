using HeyYo.Core.Data.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace HeyYo.Web.Server.Middleware.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();

                foreach (var error in errors)
                {
                    foreach (var item in error.Value)
                    {
                        errorResponse.Errors.Add(new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = item
                        });
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);

                return;
            }

            await next();
        }
    }
}
