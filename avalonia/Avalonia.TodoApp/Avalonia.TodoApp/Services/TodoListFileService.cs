using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Avalonia.TodoApp.Models;
using Path = System.IO.Path;

namespace Avalonia.TodoApp.Services;

/// <summary>
/// </summary>
public static class TodoListFileService
{
    /// <summary>
    ///     数据存储路径
    /// </summary>
    private static readonly string _jsonFileName =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Avalonia.TodoApp",
            "MyTodoList.json");

    /// <summary>
    ///     保存 To-do 列表数据到文件中
    /// </summary>
    /// <param name="todoItems"></param>
    public static async Task SaveToFileAsync(IEnumerable<TodoItem> todoItems)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);
        await using var fs = File.Create(_jsonFileName);
        await JsonSerializer.SerializeAsync(fs, todoItems);
    }

    /// <summary>
    ///     从文件中加载 To-do 列表数据
    /// </summary>
    /// <returns>To-do 列表数据</returns>
    public static async Task<IEnumerable<TodoItem>?> LoadFromFileAsync()
    {
        try
        {
            await using var fs = File.OpenRead(_jsonFileName);
            return await JsonSerializer.DeserializeAsync<IEnumerable<TodoItem>>(fs);
        }
        catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
        {
            Console.WriteLine(e);
            return [];
        }
    }
}