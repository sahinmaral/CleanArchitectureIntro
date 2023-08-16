﻿using CleanArchitectureIntro.Domain.Abstractions;
using CleanArchitectureIntro.Domain.Entities;

using System.Linq.Expressions;

namespace CleanArchitectureIntro.Domain.Repositories;

public interface IRepository<TEntity>
    where TEntity : BaseEntity,new()
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default);

    TEntity GetByExpression(Expression<Func<TEntity, bool>> expression);
    TEntity GetFirst();

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void AddAsync(TEntity entity);
    Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void UpdateRange(ICollection<TEntity> entities);
    Task DeleteByIdAsync(string id);
    Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    void DeleteRange(ICollection<TEntity> entities);
}
