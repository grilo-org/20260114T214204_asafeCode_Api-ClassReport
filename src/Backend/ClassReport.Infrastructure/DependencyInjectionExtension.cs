using System.ClientModel;
using Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Services;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Domain.Services.OpenAI;
using MyRecipeBook.Domain.ValueModel;
using MyRecipeBook.Infrastructure.Clients;
using MyRecipeBook.Infrastructure.Extensions;
using MyRecipeBook.Infrastructure.Services;
using MyRecipeBook.Infrastructure.Services.Astro;
using MyRecipeBook.Infrastructure.Services.OpenAI;
using OpenAI;
using OpenAI.Chat;
using Refit;

namespace MyRecipeBook.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services,  IConfiguration configuration)
    {
        AddServices(services);
        AddClients(services, configuration);
        AddOpenAi(services);
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IGetAccessToken, GetAccessTokenService>();
        services.AddScoped<IGetBookContent, GetBookContentService>();
        services.AddScoped<IGetBookIdAndDate, GetBookIdAndDateService>();
        services.AddScoped<IGetClasses, GetClassesService>();
        services.AddScoped<IGetTeacherInfo, GetTeacherInfoService>();
    }    
    private static void AddClients(IServiceCollection services,  IConfiguration configuration)
    {
        services.AddRefitClient<ICtrlPlayClient>()
            .ConfigureHttpClient(c => c.BaseAddress = 
                new Uri(configuration.AstroPortalClientUrl()));

        services.AddRefitClient<IOpenRouterClient>()
            .ConfigureHttpClient(c => c.BaseAddress = 
                new Uri(configuration.OpenRouterClientUrl()));
    }
    private static void AddOpenAi(IServiceCollection services)
    {
        services.AddScoped<IGenerateReportAi, OpenRouterService>();
    }
}