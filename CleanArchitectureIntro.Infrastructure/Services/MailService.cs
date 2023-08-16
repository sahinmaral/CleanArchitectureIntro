using CleanArchitectureIntro.Application.Services;

using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace CleanArchitectureIntro.Infrastructure.Services;

public sealed class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMailAsync(string email, string subject, string body)
    {
        var client = new SendGridClient(_configuration["MailService:APIKey"]);

        var from = new EmailAddress("sahin.maral@hotmail.com", "Şahin MARAL");
        var to = new EmailAddress(email);

        var strippedHtmlContent = StripHtmlTags(body);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, strippedHtmlContent, body);
        await client.SendEmailAsync(msg);
    }

    private string StripHtmlTags(string input)
    {
        return Regex.Replace(input, "<.*?>", string.Empty);
    }
}
