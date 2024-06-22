using System.Xml.Linq;
using XmlParse.Example.Enums;
using XmlParse.Example.Models;

namespace XmlParse.Example;

internal static class Program
{
    /// <summary>
    /// 解析 pdm xml 文档
    /// </summary>
    private static void Main()
    {
        // 读取 pdm xml 文档  
        const string filePath = @"D:\test.xml";
        // 加载 xml 文档
        var pdmRootEle = XElement.Load(filePath);
        // 查找所有表对象
        var tableElements = GetTableElements(pdmRootEle);

        foreach (var table in tableElements)
        {
            Console.WriteLine("======================== 表信息 =========================");
            Console.WriteLine(table);
            if (table.Columns == null)
            {
                continue;
            }

            Console.WriteLine("======================== 列信息 =========================");
            foreach (var column in table.Columns)
            {
                Console.WriteLine(column);
            }
        }
    }

    /// <summary>
    /// 获取所有表对象
    /// <param name="rootElement">文档根节点</param>
    /// <returns>表信息列表</returns>
    /// </summary>
    private static IEnumerable<Table> GetTableElements(XElement rootElement)
    {
        return rootElement.Descendants(
                XName.Get(CollectionElements.Tables.GetDescription(), Namespace.C.GetDescription())
            )
            .First()
            .Elements(XName.Get(ObjectElements.Table.GetDescription(), Namespace.O.GetDescription()))
            .Select(item => new Table
            {
                Code = item.Element(
                    XName.Get(AttributeElements.Code.GetDescription(), Namespace.A.GetDescription())
                )?.Value,
                Name = item.Element(
                    XName.Get(AttributeElements.Name.GetDescription(), Namespace.A.GetDescription())
                )?.Value,
                Columns = GetColumns(item)
            });
    }

    /// <summary>
    /// 获取所有列对象
    /// <param name="tableElement">表对象</param>
    /// <returns>列信息列表</returns>
    /// </summary>
    private static IEnumerable<Column>? GetColumns(XElement tableElement)
    {
        return tableElement.Element(
                XName.Get(CollectionElements.Columns.GetDescription(), Namespace.C.GetDescription())
            )
            ?.Elements(XName.Get(ObjectElements.Column.GetDescription(), Namespace.O.GetDescription()))
            .Select(column =>
            {
                var id = column.Attribute(AttributeNames.Id.GetDescription())!.Value;

                return new Column
                {
                    Id = id,
                    Code = column.Element(
                        XName.Get(AttributeElements.Code.GetDescription(), Namespace.A.GetDescription())
                    )?.Value,
                    Name = column.Element(
                        XName.Get(AttributeElements.Name.GetDescription(), Namespace.A.GetDescription())
                    )?.Value,
                    DataType = column.Element(
                        XName.Get(AttributeElements.DataType.GetDescription(), Namespace.A.GetDescription())
                    )?.Value,
                    Mandatory = "1".Equals(
                        column.Element(
                            XName.Get(AttributeElements.Mandatory.GetDescription(),
                                Namespace.A.GetDescription())
                        )?.Value
                    ),
                    Length = int.Parse(
                        column.Element(
                            XName.Get(AttributeElements.Length.GetDescription(),
                                Namespace.A.GetDescription())
                        )?.Value ?? "0"
                    ),
                    IsPrimaryKey = CheckIsPrimaryKey(tableElement, id)
                };
            });
    }

    /// <summary>
    /// 检查列是否为主键
    /// <param name="tableElement">表元素</param>
    /// <param name="columnId">列Id</param>
    /// <returns>如果列是主键则返回：<c>true</c>，否则返回：<c>false</c></returns>
    /// </summary>
    private static bool CheckIsPrimaryKey(XElement tableElement, string columnId)
    {
        // TODO 待修复BUG：没有主键时会导致解析失败 
        var primaryKey = tableElement.Elements(
                XName.Get(CollectionElements.PrimaryKey.GetDescription(), Namespace.C.GetDescription())
            )
            .First()
            .Elements(XName.Get(ObjectElements.Key.GetDescription(), Namespace.O.GetDescription()))
            .Select(item => new Key
            {
                Ref = item.Attribute(AttributeNames.Ref.GetDescription())?.Value
            })
            .First();
        return tableElement.Element(
                XName.Get(CollectionElements.Keys.GetDescription(), Namespace.C.GetDescription())
            )?
            .Elements(XName.Get(ObjectElements.Key.GetDescription(), Namespace.O.GetDescription()))
            .Select(item => new Key
            {
                Id = item.Attribute(AttributeNames.Id.GetDescription())!.Value,
                Code = item.Element(
                    XName.Get(AttributeElements.Code.GetDescription(), Namespace.A.GetDescription())
                )?.Value,
                Name = item.Element(
                    XName.Get(AttributeElements.Name.GetDescription(), Namespace.A.GetDescription())
                )?.Value,
                KeyColumns = GetKeyColumns(item)
            })
            .Where(item => item.Id.Equals(primaryKey.Ref))
            .Any(item =>
                item.KeyColumns != null && item.KeyColumns.Any(keyColumn => columnId.Equals(keyColumn.Ref))) ?? false;
    }

    /// <summary>
    /// 获取表对象中的所有键约束列表
    /// <param name="tableElement">表元素</param>
    /// <returns>键约束列表</returns>
    /// </summary>
    private static IEnumerable<Column>? GetKeyColumns(XElement tableElement)
    {
        return tableElement.Element(
                XName.Get(CollectionElements.KeyColumns.GetDescription(),
                    Namespace.C.GetDescription())
            )
            ?.Elements(XName.Get(ObjectElements.Column.GetDescription(),
                Namespace.O.GetDescription()))
            .Select(keyColumn => new Column
            {
                Ref = keyColumn.Attribute(AttributeNames.Ref.GetDescription())?.Value
            });
    }
}