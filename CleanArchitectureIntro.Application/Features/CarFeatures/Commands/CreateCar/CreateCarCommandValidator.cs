using FluentValidation;

namespace CleanArchitectureIntro.Application.Features.CarFeatures.Commands.CreateCar;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
	public CreateCarCommandValidator()
	{
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model boş bırakılamaz");
        RuleFor(x => x.Model).MinimumLength(2).WithMessage("Model , en az 2 karakter uzunluğunda olmalıdır");
        RuleFor(x => x.Model).MaximumLength(50).WithMessage("Model , en fazla 50 karakter uzunluğunda olmalıdır");

        RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim , en az 2 karakter uzunluğunda olmalıdır");
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Model , en fazla 50 karakter uzunluğunda olmalıdır");

        RuleFor(x => x.EnginePower).GreaterThan(0).WithMessage("Motor gücü sıfırdan büyük olmalıdır");
    }
}
