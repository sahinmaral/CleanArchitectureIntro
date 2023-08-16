using CleanArchitectureIntro.Domain.Abstractions;
using CleanArchitectureIntro.Domain.Dtos;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureIntro.Persistance.Extensions;

public static class EntityPaginationExtension
{
    public static async Task<PaginationResult<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> data, int pageSize, int pageNumber)
        where TEntity : BaseEntity,new()
    {
        int totalDataCount = await data.CountAsync();

        int totalPages = (int)Math.Ceiling(totalDataCount / (double)pageSize);
        bool isFirstPage = pageNumber == 1;
        bool isLastPage = pageNumber == totalPages;

        var pagedData = await data
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginationResult<TEntity>(pagedData, pageNumber, pageSize, totalPages, totalDataCount,isFirstPage, isLastPage);
    }
}
