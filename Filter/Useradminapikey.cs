
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace TentamenProjeketet.Filter
 
{
    public class Useradminapikey : Attribute, IAsyncActionFilter
    {
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        //throw new NotImplementedException();


        var _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var Apikey = _configuration.GetValue<string>("Apikeys:adminapikey");

        // Adminapikey is different by Header with Apiket
        if (!context.HttpContext.Request.Headers.TryGetValue("key", out var key))
        {

            context.Result = new UnauthorizedResult();
            return;

        }

        if (!Apikey.Equals(key))
        {

            context.Result = new UnauthorizedResult();
            return;
        }
        await next();
    }

}
}
