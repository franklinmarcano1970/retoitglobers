using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vtex.api.core.Models;

namespace vtex.api.core.Security
{
    /// <summary>
    /// Clase para encapsular la peticion y poder administrar el consumo de la ApiRest vit api key
    /// </summary>
    public class SimpleFilterRules : IActionFilter
    {
        private AplicationConfig _config;

        public SimpleFilterRules(IOptions<AplicationConfig> config)
        {
            _config = config.Value;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var keyPost = context.HttpContext.Request.Headers["x-api-key"];
            var isReferer = context.HttpContext.Request.Headers["Referer"].ToString().Contains("swagger");
            if (!isReferer) 
            { 
                if (keyPost.FirstOrDefault() != _config.KeyApi)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }

    }
}
