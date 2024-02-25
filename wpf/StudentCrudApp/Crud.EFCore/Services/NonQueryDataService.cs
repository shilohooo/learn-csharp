namespace Crud.EFCore.Services;

/// <summary>
/// 非查询数据操作 Service
/// </summary>
/// <typeparam name="T">实体类型</typeparam>
public class NonQueryDataService<T>(StudentDbContextFactory contextFactory) where T : class
{
    /// <summary>
    /// 新增记录
    /// </summary>
    /// <param name="entity">要新增的实体对象实例</param>
    /// <returns>新增成功的实体对象实例</returns>
    public async Task<T> CreateAsync(T entity)
    {
        await using var studentDbContext = contextFactory.CreateDbContext();
        var addResult = await studentDbContext.Set<T>().AddAsync(entity);
        await studentDbContext.SaveChangesAsync();
        return addResult.Entity;
    }

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="entity">要删除的实体对象实例</param>
    /// <returns>删除成功返回 true，否则返回 false</returns>
    public async Task<bool> DeleteAsync(T entity)
    {
        await using var studentDbContext = contextFactory.CreateDbContext();
        studentDbContext.Set<T>().Remove(entity);
        await studentDbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <param name="entity">要更新的实体对象实例</param>
    /// <returns>更新成功的实体对象实例</returns>
    public async Task<T> UpdateAsync(T entity)
    {
        await using var studentDbContext = contextFactory.CreateDbContext();
        studentDbContext.Set<T>().Update(entity);
        await studentDbContext.SaveChangesAsync();
        return entity;
    }
}