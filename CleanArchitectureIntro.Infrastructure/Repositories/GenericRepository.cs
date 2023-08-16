﻿using CleanArchitectureIntro.Domain.Abstractions;
using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace CleanArchitectureIntro.Infrastructure.Repositories;

public class GenericRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext
{
    private readonly TContext _context;
    private DbSet<TEntity> Entity;

    public GenericRepository(TContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }

    public void AddAsync(TEntity entity)
    {
        Entity.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }

    public async Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
    }

    public void Delete(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public async Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        TEntity entity = await Entity.FindAsync(id).ConfigureAwait(false);
        Entity.Remove(entity);
    }

    public void DeleteRange(ICollection<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }

    public IQueryable<TEntity> GetAll()
    {
        return Entity.AsNoTracking().AsQueryable();
    }

    public TEntity GetByExpression(Expression<Func<TEntity, bool>> expression)
    {
        TEntity entity = Entity.Where(expression).AsNoTracking().FirstOrDefault();
        return entity;
    }

    public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        return entity;
    }

    public TEntity GetFirst()
    {
        TEntity entity = Entity.AsNoTracking().FirstOrDefault();
        return entity;
    }

    public async Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity.AsNoTracking().FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        return entity;
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.AsNoTracking().Where(expression).AsQueryable();
    }

    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        Entity.UpdateRange(entities);
    }

}
