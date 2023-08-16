using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Dtos;

using MediatR;

namespace CleanArchitectureIntro.Application.Features.ErrorLogFeatures.Commands.CreateErrorLog;

public sealed class CreateErrorLogHandler : IRequestHandler<CreateErrorLogCommand, MessageResponse>
{
    private readonly IErrorLogService _errorLogService;

    public CreateErrorLogHandler(IErrorLogService errorLogService)
    {
        _errorLogService = errorLogService;
    }

    public async Task<MessageResponse> Handle(CreateErrorLogCommand request, CancellationToken cancellationToken)
    {
        await _errorLogService.CreateAsync(request, cancellationToken);

        return new("Hata log başarıyla kaydedildi");
    }
}
