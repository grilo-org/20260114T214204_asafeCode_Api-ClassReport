using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.API.Attributes;
using MyRecipeBook.Application.UseCases.AstroPortal.TodayClasses;

namespace MyRecipeBook.API.Controllers;

[AuthenticatedUser]
public class ClassesController : ClassReportControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IGetTodayClassesUseCase useCase)
    {
        var response = await  useCase.Execute();
        return Ok(response);
    }
}