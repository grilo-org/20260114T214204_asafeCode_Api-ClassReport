using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.Teacher;
using MyRecipeBook.Domain.Security.Tokens;
using MyRecipeBook.Domain.Services.AstroPortal;

namespace MyRecipeBook.Application.UseCases.AstroPortal.TeacherInfo;

public class GetTeacherInfoUseCase : IGetTeacherInfoUseCase
{
    private readonly IGetTeacherInfo _services;
    private readonly ITokenProvider _token;

    public GetTeacherInfoUseCase(IGetTeacherInfo services, ITokenProvider token)
    {
        _services = services;
        _token = token;
    }
    public async Task<TeacherResponseDto> Execute()
    {
        var token = _token.Value();
        var teacher = await _services.GetTeacherInfo(token);
        
        return teacher;
    }
}