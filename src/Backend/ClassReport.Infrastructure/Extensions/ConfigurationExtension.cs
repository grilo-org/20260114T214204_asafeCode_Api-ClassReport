using Microsoft.Extensions.Configuration;


namespace MyRecipeBook.Infrastructure.Extensions;

public static class ConfigurationExtension
{
    public static string OpenRouterClientUrl(this IConfiguration configuration)
    {
        return configuration.GetValue<string>("Settings:Urls:OpenRouter")!;
        
    }
    public static string AstroPortalClientUrl(this IConfiguration configuration)
    {
        return configuration.GetValue<string>("Settings:Urls:AstroPortal")!;
    } 
}