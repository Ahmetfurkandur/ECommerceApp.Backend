using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                // ModelStateDictionary'deki hataları al
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).ToList();

                // Hata mesajlarını string bir listeye dönüştür
                var errorMessages = new List<string>();
                errors.ForEach(x =>
                {
                    errorMessages.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorMessages);
                return;
            }

            await next();
        }
    }
}
