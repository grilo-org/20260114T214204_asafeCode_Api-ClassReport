using MyRecipeBook.Domain.Dtos.Responses.Classes;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetClassesService : IGetClasses
{
    private readonly ICtrlPlayClient _client;
    public GetClassesService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<ClassesResponseDto> GetClassesToday(string accessToken, string today, string statusClass = "IN_PROGRESS")
    {
        var response = await _client.GetClasses(accessToken, today);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.NO_TOKEN);

        if (response.Content!.Results.Count <= 0)
            throw new NotFoundException(ResourceMessagesException.NO_CLASSES_TODAY);
        
        return response.Content!;
    }
}