using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.API.Attributes;
using MyRecipeBook.Application.UseCases.AstroPortal.GenerateReport;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.API.Controllers;

[AuthenticatedUser]
public class GenerateReportController :  ClassReportControllerBase
{
    [HttpPost("/Generate-Report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromServices] IGenerateReportUseCase useCase,
        [FromBody] RequestClassId request)
    {
        var response = await  useCase.Execute(request);
        return Ok(response);
    }
}