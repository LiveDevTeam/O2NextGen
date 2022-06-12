using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace O2NextGen.MediaBasket.Api.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (context.ExceptionHandled is DbUpdateConcurrencyException)
            {
                context.Result =
                    new ConflictObjectResult(new { Message = "Entity was updated, please refresh your copy." });
            }
        }
    }
}