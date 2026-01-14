using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.AstroPortal.Login;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.API.Controllers;

public class LoginController : ClassReportControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] RequestLoginJson request,
        [FromServices] IGetAcessTokenUseCase useCase)
    {
        var response = await  useCase.Execute(request);
        return Ok(response);
    }
}