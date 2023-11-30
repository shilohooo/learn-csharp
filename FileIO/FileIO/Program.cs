namespace FileIO;

/// <summary>
/// C#中的文件读写
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        // FileReadWriteTest();
        // TextFileReadTest("io-test.txt");
        TextFileWriteTest("io-write-test.txt");
        const string binaryFilePath = "io-binary-test";
        WriteContentToBinaryFile(binaryFilePath);
        ReadContentFromBinaryFile(binaryFilePath);
    }

    /// <summary>
    /// 文件读写测试
    /// </summary>
    private static void FileReadWriteTest()
    {
        // 使用 FileStream 操作指定的文件
        // FileMode 设定文件的打开方式：OpenOrCreate = 打开指定文件，如果该文件不存在，则创建一个新的文件并打开
        // FileAccess 设定文件的操作类型：ReadWrite = 读和写
        var fileStream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        for (var i = 0; i < 20; i++)
        {
            // 往文件中写入内容
            fileStream.WriteByte((byte)i);
        }

        // 将光标移动回文件开头的位置
        fileStream.Position = 0;
        // 读取文件内容
        for (var i = 0; i < 20; i++)
        {
            Console.Write($"{fileStream.ReadByte()} ");
        }

        // 关闭文件流
        fileStream.Close();
    }

    /// <summary>
    /// 文本文件读测试
    /// </summary>
    /// <param name="filePath">文件路径</param>
    private static void TextFileReadTest(string filePath)
    {
        try
        {
            // 创建 StreamReader 类的对象
            // 注意，当前目录位置: bin/Debug/net8.0
            var streamReader = new StreamReader(filePath);
            string? line;
            // 从文件中读取内容，一行一行的读
            while ((line = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"文件内容读取失败：{e}");
        }
    }

    /// <summary>
    /// 文本文件写入测试
    /// </summary>
    /// <param name="filePath">文件路径</param>
    public static void TextFileWriteTest(string filePath)
    {
        // 定义要写入文件的内容
        string[] contents =
        {
            "hello world!!!!",
            "正在学习C#文件操作~",
            "https://www.baidu.com"
        };

        // 创建 StreamWriter 类的实例
        var streamWriter = new StreamWriter(filePath);
        // 将数组中的数组写入到文件中
        foreach (var content in contents)
        {
            streamWriter.WriteLine(content);
        }

        // 关闭 streamWriter
        streamWriter.Close();
        // 读取文件中的内容
        TextFileReadTest(filePath);
    }

    /// <summary>
    /// 写入内容到指定的二进制文件中
    /// </summary>
    /// <param name="filePath">文件路径</param>
    public static void WriteContentToBinaryFile(string filePath)
    {
        BinaryWriter? binaryWriter = null;
        try
        {
            // 创建文件
            binaryWriter = new BinaryWriter(
                new FileStream(filePath, FileMode.Create)
            );
            // 写入数据到文件
            binaryWriter.Write(25);
            binaryWriter.Write(3.1415926);
            binaryWriter.Write(true);
            binaryWriter.Write("hello c#");
        }
        catch (IOException e)
        {
            Console.WriteLine($"文件：{filePath} 创建失败：{e}");
        }
        finally
        {
            if (binaryWriter != null)
            {
                binaryWriter.Flush();
                binaryWriter.Close();
            }
        }
    }

    /// <summary>
    /// 从指定的二进制文件中
    /// </summary>
    /// <param name="filePath">文件路径</param>
    public static void ReadContentFromBinaryFile(string filePath)
    {
        BinaryReader? binaryReader = null;
        try
        {
            // 打开文件并读取
            binaryReader = new BinaryReader(
                new FileStream(filePath, FileMode.Open)
            );
            Console.WriteLine($"Integer data: {binaryReader.ReadInt32()}");
            Console.WriteLine($"Double data: {binaryReader.ReadDouble()}");
            Console.WriteLine($"Bool data: {binaryReader.ReadBoolean()}");
            Console.WriteLine($"String data: {binaryReader.ReadString()}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"读取文件：{filePath} 的内容失败：{e}");
        }
        finally
        {
            binaryReader?.Close();
        }
    }
}