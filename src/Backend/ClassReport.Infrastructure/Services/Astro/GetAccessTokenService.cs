using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Dtos.Responses.Login;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.AstroPortal;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.Astro;

public class GetAccessTokenService : IGetAccessToken
{
    private readonly ICtrlPlayClient _client;
    public GetAccessTokenService(ICtrlPlayClient client)
    {
        _client = client;
    }
    public async Task<TokenReponseDto> GetAccessToken(RequestLoginDto request)
    {
        var response = await _client.Login(request);
        if (response.IsSuccessful.IsFalse()) 
            throw new ExternalServiceException(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID);
        return response.Content!;
    }
}