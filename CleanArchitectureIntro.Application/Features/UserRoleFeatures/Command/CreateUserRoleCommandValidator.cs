using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;

using FluentValidation;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
	public CreateUserRoleCommandValidator()
	{
		RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı ID boş bırakılamaz");
        RuleFor(x => x.RoleId).NotEmpty().WithMessage("Rol ID boş bırakılamaz");   
	}
}

