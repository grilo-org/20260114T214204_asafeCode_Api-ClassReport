using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.Classes;

namespace MyRecipeBook.Application.UseCases.AstroPortal.TodayClasses;

public interface IGetTodayClassesUseCase
{
    public Task<ClassesResponseDto> Execute();
    
}