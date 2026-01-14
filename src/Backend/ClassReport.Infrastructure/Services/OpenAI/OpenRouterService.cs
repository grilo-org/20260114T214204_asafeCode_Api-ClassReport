using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Dtos.Requests;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.OpenAI;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using MyRecipeBook.Infrastructure.Clients;

namespace MyRecipeBook.Infrastructure.Services.OpenAI;

public class OpenRouterService : IGenerateReportAi
{
    private readonly IOpenRouterClient _chatClient;
    private readonly string _apiKey;
    public OpenRouterService(IOpenRouterClient client , IConfiguration configuration)
    {
        _chatClient = client;
        _apiKey = configuration.GetValue<string>("Settings:OpenAI:ApiKey")!;
    }

    public async Task<string> Generate(GenerateReportDto request)
    {
        var prompt = PromptReportGenerator.Generate(request);
         
        var requestChat = new ChatRequestDto
        {
            Messages = [
                new MessageDto { Role = "user", Content = prompt}
            ]
        };
        
        var response = await _chatClient.Generate(_apiKey, requestChat);
        if (response.IsSuccessStatusCode.IsFalse())
            throw new ExternalServiceException(ResourceMessagesException.IA_SERVICE_NOT_WORKING);
                
        return response.Content!.Choices.FirstOrDefault()!.Message.Content;
    }
}