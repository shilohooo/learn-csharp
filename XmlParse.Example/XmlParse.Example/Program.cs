using System.Xml;

namespace XmlParse.Example;

class Program
{
    static void Main(string[] args)
    {
        // 读取 D 盘下面的 test.xml 文件的内容
        var xml = File.ReadAllText(@"D:\test.xml");
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(xml);
        var rootEl = xmlDocument.DocumentElement;
        Console.WriteLine(rootEl?.Name);
    }
}