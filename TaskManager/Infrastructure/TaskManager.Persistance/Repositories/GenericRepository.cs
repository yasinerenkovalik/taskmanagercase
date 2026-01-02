using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TaskManager.Application.Interface.Repository;
using TaskManager.Domain.Entities;
using TaskManager.Persistance.Context;



namespace TaskManager.Persistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly TaskManagerContext _appContext;
    public GenericRepository(TaskManagerContext appContext)
    {
        _appContext = appContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        entity.CreateDate = DateTime.UtcNow;
        entity.IsActivated = true;

        await _appContext.Set<T>().AddAsync(entity);
        await _appContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteAsync(Guid id)
    {
        var entity = await _appContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new Exception("Entity not found");

        entity.IsActivated = false;
        entity.DeleteDate = DateTime.UtcNow;

        _appContext.Set<T>().Update(entity);
        await _appContext.SaveChangesAsync();

        return entity;
    }

    public async Task<PagedResult<T>> GetPagedAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var query = _appContext.Set<T>()
            .Where(x => x.IsActivated == true);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

   
    public async Task<PagedResult<TResult>> GetPagedAsync<TResult>(
        int pageNumber,
        int pageSize,
        CancellationToken ct,
        Func<IQueryable<T>, IQueryable<TResult>> selector,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
        where TResult : class
    {
        IQueryable<T> baseQuery = _appContext.Set<T>()
            .Where(x => x.IsActivated)
            .AsNoTracking();

        var totalCount = await baseQuery.CountAsync(ct);

        if (orderBy != null)
            baseQuery = orderBy(baseQuery);

        var pageItems = await selector(baseQuery)      
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return new PagedResult<TResult>
        {
            Items = pageItems,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

  
    public async Task<List<T>> GetAllAysnc()
    {
        return await _appContext.Set<T>()
            .Where(o => o.IsActivated == true)
            .ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid Id)
    {
        return await _appContext.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == Id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        entity.UpdateDate = DateTime.UtcNow;

        _appContext.Set<T>().Update(entity);
        await _appContext.SaveChangesAsync();

        return entity;
    }
}
