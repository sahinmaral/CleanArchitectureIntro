using CleanArchitectureIntro.Application.Features.RoleFeatures.Command;

using FluentValidation;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
	public CreateRoleCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim , en az 3 karakter olmalıdır");
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim , en fazla 50 karakter olmalıdır");		
        
	}
}

