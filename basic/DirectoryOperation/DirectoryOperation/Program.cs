namespace DirectoryOperation;

/// <summary>
/// C#中的目录操作
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // 创建一个 DirectoryInfo 类的实例
        var directoryInfo = new DirectoryInfo(@"D:\data-backup");
        Console.WriteLine($"目录信息：{directoryInfo}");

        // 获取目录中的文件
        foreach (var fileInfo in directoryInfo.GetFiles())
        {
            Console.WriteLine($"文件名称：{fileInfo.Name}，文件大小：{fileInfo.Length} bytes，文件后缀：{fileInfo.Extension}");
        }
    }
}