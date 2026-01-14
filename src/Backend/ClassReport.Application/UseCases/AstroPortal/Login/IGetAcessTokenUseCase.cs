using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.AstroPortal.Login;

public interface IGetAcessTokenUseCase
{
    public Task<ResponseLoginJson> Execute(RequestLoginJson request);
}