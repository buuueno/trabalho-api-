using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace ProdutosApi.Filters;

public class ValidationFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = new Dictionary<string, string[]>();

            foreach (var modelState in context.ModelState.Values)
            {
                var errorMessages = new List<string>();

                foreach (var error in modelState.Errors)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }

                if (errorMessages.Count > 0)
                {
                    errors.Add("errors", errorMessages.ToArray());
                    break;
                }
            }

            context.Result = new BadRequestObjectResult(errors);
        }

        base.OnActionExecuting(context);
    }
}