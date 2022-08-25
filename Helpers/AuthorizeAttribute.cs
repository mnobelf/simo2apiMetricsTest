using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using simo2api.Entities;
using Prometheus;
using simo2api.MetricsNamespace;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //var user = (User)context.HttpContext.Items["User"];
        var user = context.HttpContext.Items["User"];
        if (user == null)
        {
            AppMetrics.OnAuthorizationErrorCounter.Inc();
            // not logged in
            context.Result = new JsonResult(new { message = "Unauthorized : Username/Token !" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
        else
        {
            AppMetrics.OnAuthorizationCounter.Inc();
            AppMetrics.AuthorizationSummary.Observe(1);
        }
    }
}