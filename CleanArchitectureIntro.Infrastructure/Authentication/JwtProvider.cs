using CleanArchitectureIntro.Application.Abstractions;
using CleanArchitectureIntro.Domain.Entities;

using Microsoft.Extensions.Options;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CleanArchitectureIntro.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitectureIntro.Infrastructure.Extensions;

namespace CleanArchitectureIntro.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<User> _userManager;

    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> CreateTokenAsync(User user)
    {
        var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(JwtRegisteredClaimNames.Name,user.UserName)
        };

        var roles = (await _userManager.GetRolesAsync(user)).ToList();

        claims.AddRoles(roles.ToArray());

        var expires = DateTime.Now.AddHours(1);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer : _jwtOptions.Issuer,
            audience : _jwtOptions.Audience,
            claims : claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature));

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        string refreshToken =  GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddMinutes(15);

        await _userManager.UpdateAsync(user);

        LoginCommandResponse response = new LoginCommandResponse(
            AccessToken : token,
            RefreshToken : refreshToken,
            RefreshTokenExpires : Convert.ToDateTime(user.RefreshTokenExpires),
            UserId : user.Id
            );

        return response;
    }

    private string GenerateRefreshToken()
    {
        Guid refreshTokenGuid = Guid.NewGuid();
        return refreshTokenGuid.ToString();
    }
}
