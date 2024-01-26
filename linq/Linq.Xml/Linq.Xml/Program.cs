// Linq to XML
// LINQ to XML可以以两种方式和XML配合使用。第一种方式是作为简化的XML操作API
// 第二种方式是使用LINQ查询工具。
// LINQ to XML API由很多表示XML树组件组成。
// 主要使用3个类：XElement、XAttribute和XDocument。
// see: https://hzd.plus/2019/08/26/C-%E5%9B%BE%E8%A7%A3%E6%95%99%E7%A8%8B%E4%B9%8BLINQ/#LINQ-to-XML
// 创建、保存、加载和显示XML文档
// 示例：创建一个包含 Employees 节点的 XML 树

using System.Xml.Linq;

var employeesDocument = new XDocument(
    // 创建元素
    new XElement(
        // 设置元素名称
        "Employees",
        // 创建元素，设置元素名称以及内容
        new XElement("Name", "Bob Smith"),
        new XElement("Name", "Bruce Lee")
    )
);
employeesDocument.Save("EmployeesFile.xml");
// 加载 XML 文档
var employeesDocument2 = XDocument.Load("EmployeesFile.xml");
Console.WriteLine(employeesDocument2);
Console.WriteLine();

// 创建 XML 树
var employeesDocument3 = new XDocument(
    // 创建根元素
    new XElement(
        // 设置根元素名称
        "Employees",
        new XElement(
            // 设置元素名称
            "Employee",
            // 创建子元素
            new XElement("Name", "Bob Smith"),
            new XElement("PhoneNumber", "408-555-1110")
        ),
        new XElement(
            // 设置元素名称
            "Employee",
            // 创建子元素
            new XElement("Name", "Bob Smith"),
            new XElement("PhoneNumber", "408-555-2222"),
            new XElement("PhoneNumber", "408-555-3333")
        )
    )
);
Console.WriteLine(employeesDocument3);
Console.WriteLine();

// 使用 XML 树的值
// 示例：通过遍历获取节点的值
// 获取第一个名为 Employee 的子节点
var rootEle = employeesDocument3.Element("Employees");
var childElements = rootEle?.Elements();
if (childElements is null)
{
    return;
}

foreach (var childEle in childElements)
{
    // 获取名称
    var nameNode = childEle.Element("Name");
    Console.WriteLine($"Name: {nameNode?.Value}");
    // 获取手机号码
    var phoneNumberNodes = childEle.Elements("PhoneNumber");
    foreach (var phoneNumberNode in phoneNumberNodes)
    {
        Console.WriteLine($"PhoneNumber: {phoneNumberNode.Value}");
    }
}

Console.WriteLine();

// 增加节点以及操作 XML
// 示例：使用 Add 方法为现有元素增加子元素
Console.WriteLine("Origin Tree");
Console.WriteLine(employeesDocument3);
Console.WriteLine();

var rootElement = employeesDocument3.Element("Employees");
rootElement?.Add(new XElement("Second"));
rootElement?.Add(
    new XElement("Third"),
    new XComment("Important Comment"),
    new XElement("Fourth")
);
Console.WriteLine("Modified Tree");
Console.WriteLine(employeesDocument3);
Console.WriteLine();

// 使用 XML 特性、
// 示例 为根节点增加两个特性（即属性）
var documentWithAttributes = new XDocument(
    // XDeclaration
    // XML文档从包含XML使用的版本号、使用的字符编码类型以及文档是否依赖外部引用的一行开始。
    // 这叫做XML声明。
    new XDeclaration("1.0", "UTF-8", "yes"),
    new XElement(
        "Root",
        new XAttribute("Color", "Red"),
        new XAttribute("Size", "Large"),
        new XElement("First"),
        new XElement("Second")
    )
);
Console.WriteLine(documentWithAttributes);
documentWithAttributes.Save("DocumentWithAttributes.xml");
Console.WriteLine();
// 获取特性（即属性）
var rootElementWithAttributes = documentWithAttributes.Element("Root");
var colorAttribute = rootElementWithAttributes?.Attribute("Color");
Console.WriteLine($"Color is {colorAttribute?.Value}");
var sizeAttribute = rootElementWithAttributes?.Attribute("Size");
Console.WriteLine($"Size is {sizeAttribute?.Value}");
Console.WriteLine();
// 移除特性
rootElementWithAttributes?.Attribute("Color")?.Remove();
// 移除特性的第二种方式，将特性的值设置为 null
// rootElementWithAttributes?.SetAttributeValue("Size", null);
Console.WriteLine(documentWithAttributes);
Console.WriteLine();
// 增加或改变特性的值
// 修改特性的值
rootElementWithAttributes?.SetAttributeValue("Size", "Medium");
// 增加特性
rootElementWithAttributes?.SetAttributeValue("Width", "Narrow");
Console.WriteLine(documentWithAttributes);
Console.WriteLine();

// 节点的其他类型
// XComment：表示 XML 文档中的注释内容
rootElementWithAttributes?.Add(new XComment("This is a comment"));
Console.WriteLine(documentWithAttributes);
Console.WriteLine();

// XProcessingInstruction
// XML处理指令用于提供XML文档如何被使用和翻译的额外数据，
// 最常见的就是把处理指令用于关联XML文档和一个样式表。
// 没找到具体用法:(

// 使用 Linq to XML 的 Linq 查询
var xDocument = new XDocument(
    new XElement("MyElements",
        new XElement("First",
            new XAttribute("Color", "red"),
            new XAttribute("Size", "small")),
        new XElement("Second",
            new XAttribute("Color", "red"),
            new XAttribute("Size", "medium")),
        new XElement("Third",
            new XAttribute("Color", "blue"),
            new XAttribute("Size", "large"))
    )
);
Console.WriteLine(xDocument);
xDocument.Save("LinqToXmlSample.xml");
Console.WriteLine();

// 示例：使用 Linq 查询 XML中节点的子集
var linqToXmlSampleDoc = XDocument.Load("LinqToXmlSample.xml");
var rt = linqToXmlSampleDoc.Element("MyElements");
// 选择名称长度为5个字符的元素
var matchedElements = from e in rt?.Elements()
    where e.Name.ToString().Length == 5
    select e;
foreach (var matchedElement in matchedElements)
{
    Console.WriteLine(
        $"Name: {matchedElement.Name}, Color: {matchedElement.Attribute("Color")?.Value}, Size: {matchedElement.Attribute("Size")?.Value}"
    );
}

Console.WriteLine();

// 获取 XML 树的所有顶层元素，并为每个元素创建匿名类型的对象
var allRootElements = from e in rt?.Elements()
    select new { e.Name, color = e.Attribute("Color") };
foreach (var ele in allRootElements)
{
    Console.WriteLine(ele);
    Console.WriteLine("{0, -6}, color: {1, -7}", ele.Name, ele.color.Value);
}