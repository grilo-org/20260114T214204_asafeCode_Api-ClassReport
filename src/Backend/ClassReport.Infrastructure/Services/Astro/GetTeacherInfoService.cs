using System.Runtime.InteropServices;
using MyRecipeBook.Domain.Dtos.Responses.Teacher;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetTeacherInfoService :  IGetTeacherInfo
{
    private readonly ICtrlPlayClient _client;
    public GetTeacherInfoService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<TeacherResponseDto> GetTeacherInfo(string accessToken)
    {
        var response = await _client.GetTeacherInfo(accessToken);
        if (response.IsSuccessStatusCode.IsFalse()) 
            throw new ExternalException(ResourceMessagesException.NO_TOKEN);
        
        return response.Content!;
    }
}