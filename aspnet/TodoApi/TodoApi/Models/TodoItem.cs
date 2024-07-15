using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TodoApi.Converters;

namespace TodoApi.Models;

/// <summary>
/// 实体
/// </summary>
public class TodoItem
{
    public int Id { get; set; }

    [Required(ErrorMessage = "待办事项不能为空")]
    [StringLength(50, ErrorMessage = "待办事项长度不能超过 50 个字符")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "待办事项状态不能为空")]
    public bool IsComplete { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [JsonConverter(typeof(CustomJsonDateTimeOffsetConverter))]
    public DateTimeOffset? CreatedAt { get; set; }
}