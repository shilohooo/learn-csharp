namespace ZipFile.Demo;

public class ZipFileInfo(string fullPath, string fileName, string extension, string className)
{
    public string FullPath { get; set; } = fullPath;

    public string FileName { get; set; } = fileName;

    public string Extension { get; set; } = extension;

    public string ClassName { get; set; } = className;

    public byte[]? Content { get; set; }

    public long Length => Content?.Length ?? 0;

    public override string ToString()
    {
        return
            $"[{nameof(ZipFileInfo)}: {nameof(FullPath)}={FullPath}, {nameof(FileName)}={FileName}, {nameof(Extension)}={Extension}, {nameof(ClassName)}={ClassName}, {nameof(Length)}={Length} bytes]";
    }
}