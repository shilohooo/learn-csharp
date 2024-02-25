using Crud.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Crud.EFCore.Services;

/// <summary>
/// 通用数据操作 Service
/// <typeparam name="T">实体类型</typeparam>
/// </summary>
public class GenericDataService<T>(StudentDbContextFactory contextFactory) : IDataService<T>
    where T : class
{
    private readonly NonQueryDataService<T> _nonQueryDataService = new(contextFactory);

    /// <inheritdoc />
    public async Task<List<T>> GetAllAsync()
    {
        await using var studentDbContext = contextFactory.CreateDbContext();
        return await studentDbContext.Set<T>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<T> GetAsync(int id)
    {
        await using var studentDbContext = contextFactory.CreateDbContext();
        return (await studentDbContext.Set<T>().FindAsync(id).AsTask())!;
    }

    /// <inheritdoc />
    public async Task<T> CreateAsync(T entity)
    {
        return await _nonQueryDataService.CreateAsync(entity);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(T entity)
    {
        return await _nonQueryDataService.DeleteAsync(entity);
    }

    /// <inheritdoc />
    public async Task<T> UpdateAsync(T entity)
    {
        return await _nonQueryDataService.UpdateAsync(entity);
    }
}