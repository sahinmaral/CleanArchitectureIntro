using AutoMapper;

using CleanArchitectureIntro.Application.Features.ErrorLogFeatures.Commands.CreateErrorLog;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Persistance.Context;

namespace CleanArchitectureIntro.Persistance.Services;

public sealed class ErrorLogService : IErrorLogService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public ErrorLogService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateErrorLogCommand request, CancellationToken cancellationToken)
    {
        ErrorLog newErrorLog = _mapper.Map<ErrorLog>(request);

        await _context.Set<ErrorLog>().AddAsync(newErrorLog, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
