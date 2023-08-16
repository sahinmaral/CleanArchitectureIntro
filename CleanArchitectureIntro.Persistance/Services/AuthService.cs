using AutoMapper;

using CleanArchitectureIntro.Application.Abstractions;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.RefreshToken;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.VerifyAccount;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Web;

namespace CleanArchitectureIntro.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly IMailService _mailService;

    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager
            .Users
            .Where(x => x.UserName == request.UsernameOrEmail || 
            x.Email == request.UsernameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new Exception("Bu kullanıcı adında ya da mail adresine sahip bir kullanıcı yok");

        var passwordCheckResult = await _userManager.CheckPasswordAsync(user, request.Password);
        if(!passwordCheckResult)
            throw new Exception("Girdiğiniz kullanıcı adı veya email ile birlikte şifreyi yanlış girdiniz");

        if(!user.EmailConfirmed)
            throw new Exception("Lütfen kayıt olduğunuz email adresi içerisinde gelen mail üzerinden hesabınızı onaylayınız");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);

        return response;
    }

    public async Task<LoginCommandResponse> RefreshTokenAsync(RefreshTokenCommand request)
    {
        User? user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            throw new Exception("Bu kullanıcı id ye sahip bir kullanıcı yok");

        if (user.RefreshToken != request.RefreshToken)
            throw new Exception("Refresh token geçerli değil");

        if(user.RefreshTokenExpires < DateTime.Now)
            throw new Exception("Refresh token süresi dolmuş");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        var newUser = _mapper.Map<User>(request);
        
        var result = await _userManager.CreateAsync(newUser,request.Password);

        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        await _userManager.AddToRoleAsync(newUser, "User");

        string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

        string confirmationTokenHTMLVersion = HttpUtility.UrlEncode(confirmationToken);

        string callbackUrl = "https://localhost:7228/api/Auth/verify?Username=" +
            request.UserName + "&Token=" + confirmationTokenHTMLVersion;


        string body = $"<!DOCTYPE html>" +
        $"\r\n<html lang=\"en\">\r\n" +
            $"<head>\r\n    " +
            $"<meta charset=\"UTF-8\">\r\n    " +
            $"<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
            $"<title>Kullanıcı hesap onayı - Clean Architecture Intro</title>\r\n" +
            $"</head>\r\n" +
            $"<body style=\"font-family: Arial, sans-serif; margin: 0; padding: 0;\">\r\n    " +
            $"<div style=\"background-color: #f2f2f2; padding: 20px;\">\r\n        " +
            $"<div style=\"max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 20px; border-radius: 5px; box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);\">\r\n            " +
            $"<h2>Kullanıcı hesap onayı</h2>\r\n            <p>Merhaba {request.UserName},</p>\r\n            " +
            $"<p>Clean Architecture Intro kaydolduğun için teşekkürler! Giriş yapmak için lütfen aşağıdaki linke tıklayınız:</p>\r\n            " +
            $"<p>\r\n                <a href=\"" + callbackUrl + "\" style=\"background-color: #007bff; color: white; text-decoration: none; padding: 10px 20px; border-radius: 5px; display: inline-block;\">" +
            $"Hesabını onayla</a>\r\n            </p>\r\n            <p>Eğer hesap oluşturmadıysanız, bu maili görmezden gelebilirsiniz.</p>\r\n            " +
            $"</div>\r\n    " +
            $"</div>\r\n" +
            $"</body>\r\n" +
            $"</html>\r\n";

        await _mailService.SendMailAsync(request.Email, "Kullanıcı hesap onayı - CleanArchitectureIntro",body);
    }

    public async Task VerifyAccountAsync(VerifyAccountCommand request)
    {
        User? user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
            throw new Exception("Bu kullanıcı adında bir kullanıcı yok");

        var encodedToken = HttpUtility.HtmlDecode(request.Token);

        var result = await _userManager.ConfirmEmailAsync(user, encodedToken);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);
    }
}
