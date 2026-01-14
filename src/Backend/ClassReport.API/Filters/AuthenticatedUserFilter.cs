using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.API.Filters;

public class AuthenticatedUserFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            TokenOnRequest(context);
        }
        catch (SecurityTokenExpiredException)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("TokenIsExpired")
            {
                TokenIsExpired = true,
            });
        }
        catch (ClassReportException classReportException)
        {
            context.HttpContext.Response.StatusCode = (int)classReportException.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorJson(classReportException.GetErrorMessage()));
        }
        catch
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ResourceMessagesException.USER_WITHOUT_PERMISSION_ACCESS_RESOURCE));
        }
    }
    private static string TokenOnRequest(AuthorizationFilterContext context)
    {
        var authentication = context.HttpContext.Request.Headers.Authorization.ToString();
        if (string.IsNullOrWhiteSpace(authentication))
            throw new NotFoundException(ResourceMessagesException.NO_TOKEN);
        
        return authentication["Bearer ".Length..].Trim();
    }
}