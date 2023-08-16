using CleanArchitectureIntro.Application.Features.ErrorLogFeatures.Commands.CreateErrorLog;

namespace CleanArchitectureIntro.Application.Services;

public interface IErrorLogService
{
    Task CreateAsync(CreateErrorLogCommand request, CancellationToken cancellationToken);
}
