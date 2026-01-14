using System.Text.Json;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.AiServices;
using Refit;

namespace MyRecipeBook.Infrastructure.Clients;

public interface IOpenRouterClient
{
    [Post("/chat/completions")]
    Task<IApiResponse<ChatCompletionResponse>> Generate([Header("Authorization")] string apiKey, [Body] ChatRequestDto request);
}