namespace CleanArchitectureIntro.Application.Services;

public interface IMailService
{
    Task SendMailAsync(string email, string subject, string body);
}
