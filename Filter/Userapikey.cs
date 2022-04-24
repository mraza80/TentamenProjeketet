using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TentamenProjeketet.Filter
{
    public class Userapikey : Attribute, IAsyncActionFilter
    {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {


        //throw new NotImplementedException();

        var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var Apikey = _configuration.GetValue<string>("Apikeys:Apikey");
        // if not founf parameter key in the URL
        // Make the control here

        if (!context.HttpContext.Request.Query.TryGetValue("key", out var key))
        {
            context.Result = new UnauthorizedResult();
            return;

        }

        // if the Apikey is not equal to the provide key from URL
        if (!Apikey.Equals(key))
        {
            context.Result = new UnauthorizedResult();
            return;
        }


        // will continue to the next process


        await next();




    }
}
}
