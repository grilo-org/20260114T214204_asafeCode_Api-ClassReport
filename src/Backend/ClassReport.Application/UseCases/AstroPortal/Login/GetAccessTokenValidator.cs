using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UseCases.AstroPortal.Login;

public class GetAccessTokenValidator : AbstractValidator<RequestLoginJson>
{
    public GetAccessTokenValidator()
    {
        RuleFor(request => request.Username).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(request => request.Password).NotEmpty().WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
        RuleFor(request => request.Password.Length).GreaterThan(6).WithMessage(ResourceMessagesException.INVALID_PASSWORD);

        When(request => request.Username.NotEmpty(), () =>
        {
            RuleFor(request => request.Username).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        });
    }
}