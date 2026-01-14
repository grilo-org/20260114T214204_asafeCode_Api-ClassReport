using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UseCases.AstroPortal.GenerateReport;

public interface IGenerateReportUseCase
{
    public Task<string> Execute(RequestClassId request);
}