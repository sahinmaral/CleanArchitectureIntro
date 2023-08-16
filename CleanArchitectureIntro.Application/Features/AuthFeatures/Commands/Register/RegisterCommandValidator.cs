using FluentValidation;

namespace CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
	public RegisterCommandValidator()
	{
		RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email , geçerli olmalıdır");
		
		RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz");
        RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı , en az 3 karakter olmalıdır");
        
		RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz");
        RuleFor(x => x.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük harf içermelidir");
        RuleFor(x => x.Password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük harf içermelidir");
        RuleFor(x => x.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet rakam içermelidir");
        RuleFor(x => x.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir");

	}
}
