using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Requests;

namespace MyRecipeBook.Domain.Services.OpenAI;

public interface IGenerateReportAi
{
    Task<string> Generate(GenerateReportDto request);
}