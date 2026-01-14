using MyRecipeBook.Domain.Dtos.Responses.Classes;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services.AstroPortal;

namespace MyRecipeBook.Application.UseCases.AstroPortal.TodayClasses;

public class GetTodayClassesUseCase :  IGetTodayClassesUseCase
{
    private readonly ITokenProvider _token;
    private readonly IGetClasses _service;
    public GetTodayClassesUseCase(ITokenProvider token,
        IGetClasses service)
    {
        _token = token;
        _service = service;
    }

    public async Task<ClassesResponseDto> Execute()
    {
        var token = _token.Value();
        var brasiliaNow = DateTimeInTimeZone.Brasilia();
        var today = brasiliaNow.DayToday();
        var classes = await _service.GetClassesToday(token, today);

        return classes;
    }
}