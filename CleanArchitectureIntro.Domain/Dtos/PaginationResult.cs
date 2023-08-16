using CleanArchitectureIntro.Domain.Abstractions;

namespace CleanArchitectureIntro.Domain.Dtos;

public record PaginationResult<TEntity>(
    List<TEntity> Datas,
    int PageNumber,
    int PageSize, 
    int TotalPages, 
    int TotalRecords,
    bool IsFirstPage, 
    bool IsLastPage) where TEntity : BaseEntity, new();

