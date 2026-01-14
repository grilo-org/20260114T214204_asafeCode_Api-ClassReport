using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.Teacher;

namespace MyRecipeBook.Application.UseCases.AstroPortal.TeacherInfo;

public interface IGetTeacherInfoUseCase
{
    public Task<TeacherResponseDto> Execute();
}