namespace Crud.Domain.Services;

/// <summary>
/// 实体 CRUD 操作
/// </summary>
/// <typeparam name="T">实体类型</typeparam>
public interface IDataService<T>
{
    /// <summary>
    /// 查询所有记录
    /// </summary>
    /// <returns>所有记录列表</returns>
    Task<List<T>> GetAllAsync();

    /// <summary>
    /// 根据 ID 查询单条记录
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>ID 对应的单体记录</returns>
    Task<T> GetAsync(int id);

    /// <summary>
    /// 新增实体数据
    /// </summary>
    /// <param name="entity">实体对象实例</param>
    /// <returns>新增成功的实体对象实例</returns>
    Task<T> CreateAsync(T entity);

    /// <summary>
    /// 删除记录
    /// </summary>
    /// <param name="entity">实体对象实例</param>
    /// <returns>删除成功返回 true，否则返回 false</returns>
    Task<bool> DeleteAsync(T entity);

    /// <summary>
    /// 更新记录
    /// </summary>
    /// <param name="entity">实体对象实例</param>
    /// <returns>更新成功后的实体对象实例</returns>
    Task<T> UpdateAsync(T entity);
}