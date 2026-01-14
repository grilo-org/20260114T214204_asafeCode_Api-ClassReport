using System.Text.Json;
using MyRecipeBook.Domain.Dtos.Responses;
using MyRecipeBook.Domain.Dtos.Responses.Teacher;

namespace MyRecipeBook.Domain.Services.AstroPortal;

public interface IGetTeacherInfo
{
    public Task<TeacherResponseDto> GetTeacherInfo(string accessToken);
}