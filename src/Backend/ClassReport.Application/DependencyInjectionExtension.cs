using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.UseCases.AstroPortal.GenerateReport;
using MyRecipeBook.Application.UseCases.AstroPortal.Login;
using MyRecipeBook.Application.UseCases.AstroPortal.TeacherInfo;
using MyRecipeBook.Application.UseCases.AstroPortal.TodayClasses;

namespace MyRecipeBook.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services,  IConfiguration configuration)
    {
        AddUseCases(services);
    }
    
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IGetAcessTokenUseCase, GetAccessTokenUseCase>();
        services.AddScoped<IGenerateReportUseCase, GenerateReportUseCase>();
        services.AddScoped<IGetTodayClassesUseCase, GetTodayClassesUseCase>();
        services.AddScoped<IGetTeacherInfoUseCase, GetTeacherInfoUseCase>();
        
    } 
}