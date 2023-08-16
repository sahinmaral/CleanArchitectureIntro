using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.RefreshToken;

using FluentValidation;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
	public LoginCommandValidator()
	{
		RuleFor(x => x.UsernameOrEmail).NotEmpty().WithMessage("Email ya da kullanıcı adı boş bırakılamaz");		
        
		RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz");
	}
}

