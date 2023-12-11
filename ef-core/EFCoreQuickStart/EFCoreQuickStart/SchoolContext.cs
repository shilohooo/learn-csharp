using Microsoft.EntityFrameworkCore;

namespace EFCoreQuickStart;

/// <summary>
/// 代表数据库会话，可以查询数据和保存数据到数据库中
/// <remarks>
/// <para>DbContext的功能：</para>
/// <para>管理数据库连接</para>
/// <para>配置模型 & 关系</para>
/// <para>查询数据库</para>
/// <para>保存数据到数据库</para>
/// <para>配置变更跟踪</para>
/// <para>缓存</para>
/// <para>事务管理</para>
/// </remarks>
/// </summary>
public class SchoolContext : DbContext
{
}