using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.API.Attributes;
using MyRecipeBook.Application.UseCases.AstroPortal.TeacherInfo;

namespace MyRecipeBook.API.Controllers;

[AuthenticatedUser]
public class TeacherController : ClassReportControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IGetTeacherInfoUseCase useCase)
    {
        var response = await  useCase.Execute();
        return Ok(response);
    }
}