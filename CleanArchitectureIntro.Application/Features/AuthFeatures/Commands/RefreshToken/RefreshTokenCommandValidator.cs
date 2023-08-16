using FluentValidation;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().WithMessage("Refresh token adı boş bırakılamaz");


        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı id boş bırakılamaz");

    }
}
