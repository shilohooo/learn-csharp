// 解析压缩包文件

using System.IO.Compression;
using ZipFile.Demo;

var dict = new Dictionary<string, List<ZipFileInfo>>();

const string noTopDirZip = "/Users/shiloh/Downloads/班级简介导入测试（无顶层目录）.zip";
const string noTopDirZipWithSingleClass = "/Users/shiloh/Downloads/班级简介导入测试（无顶层目录单班级）.zip";
const string hasTopDirZip = "/Users/shiloh/Downloads/班级简介导入测试文件.zip";
const string invalidZip = "/Users/shiloh/Downloads/我不是压缩包.txt";
const string hasNoImgFileZip = "/Users/shiloh/Downloads/班级简介导入测试文件（包含非图片文件）.zip";
List<string> supportImgTypes = ["jpg", "jpeg", "png"];
await using var zipFileStream = File.OpenRead(hasNoImgFileZip);
Console.WriteLine($"压缩包文件名称：{Path.GetFileName(zipFileStream.Name)}");
try
{
    await using var zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Read, false);
    var firstEntryNames = zipArchive.Entries[0].FullName.Split("/", StringSplitOptions.RemoveEmptyEntries);
    var firstTopDir = firstEntryNames[0];
    var hasTopDir = zipArchive.Entries.Select(e => e.FullName)
        // Entry 层级大于等于 3，视为包含顶层目录，即：顶层目录/班级名称/文件名称.jpg
        .Any(fullName => fullName.Split("/", StringSplitOptions.RemoveEmptyEntries).Length >= 3);
    Console.WriteLine(hasTopDir ? $"压缩包具有顶层目录：{firstTopDir}" : "压缩包没有顶层目录");

    foreach (var entry in zipArchive.Entries)
    {
        Console.WriteLine($"FullName: {entry.FullName}, Name: {entry.Name}");
        if (hasTopDir && entry.FullName.Equals($"{firstTopDir}/"))
        {
            // 顶层目录/班级名称/文件名称.jpg
            Console.WriteLine("顶层目录跳过不处理");
            continue;
        }

        var names = entry.FullName.Split("/", StringSplitOptions.RemoveEmptyEntries);
        if (string.IsNullOrWhiteSpace(entry.Name))
        {
            // 处理目录
            Console.WriteLine($"处理目录: {entry.FullName}");
            // 最后一个元素代表班级名称
            var className = names[^1];
            if (dict.ContainsKey(className)) continue;

            dict.Add(className, []);
            continue;
        }

        // 处理文件，倒数第二个元素代表班级名称，最后一个元素代表文件名称，非 jpg/png 直接跳过
        var extension = Path.GetExtension(entry.Name)[1..];
        if (!supportImgTypes.Contains(extension))
        {
            Console.WriteLine($"不支持的文件类型：{entry.Name}");
            continue;
        }

        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(entry.Name);
        var key = names[^2];
        var zipFileInfo = new ZipFileInfo(entry.FullName, fileNameWithoutExtension, extension, key);
        await using var entryFileStream = await entry.OpenAsync();
        var memoryStream = new MemoryStream();
        await entryFileStream.CopyToAsync(memoryStream);
        zipFileInfo.Content = memoryStream.ToArray();
        if (dict.TryGetValue(key, out var value))
        {
            value.Add(zipFileInfo);
            continue;
        }

        dict.Add(key, [zipFileInfo]);
    }

    // var targetDir = Path.Combine("/Users/shiloh/Downloads", $"班级简介解压测试{DateTimeOffset.Now:yyyy-MM-dd_HHmmss}");
    // Directory.CreateDirectory(targetDir);
    // foreach (var (className, files) in dict)
    // {
    //     var subDir = Path.Combine(targetDir, className);
    //     Directory.CreateDirectory(subDir);
    //     Console.WriteLine($"ClassName: {className}, FileCount: {files.Count}");
    //     foreach (var zipFileInfo in files)
    //     {
    //         if (zipFileInfo.Content is null || zipFileInfo.Length <= 0) continue;
    //
    //         var extension = Path.GetExtension(zipFileInfo.FileName);
    //         var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(zipFileInfo.FileName);
    //         var fileAbsPath = Path.Combine(subDir, $"{fileNameWithoutExtension}_{Guid.NewGuid():N}{extension}");
    //         Console.WriteLine(zipFileInfo);
    //         await File.WriteAllBytesAsync(fileAbsPath, zipFileInfo.Content);
    //     }
    // }
}
catch (Exception e)
{
    Console.WriteLine($"压缩包读取失败：{e.Message}");
    throw;
}