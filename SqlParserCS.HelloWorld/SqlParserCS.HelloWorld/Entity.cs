using Spectre.Console;

namespace SqlParserCS.HelloWorld;

/// <summary>
///     实体信息
/// </summary>
internal class Entity
{
    /// <summary>
    ///     表名称
    /// </summary>
    public string? TableName { get; init; }

    /// <summary>
    ///     注释
    /// </summary>
    public string? Comment { get; init; }

    /// <summary>
    ///     实体名称
    /// </summary>
    public string? EntityName { get; init; }

    /// <summary>
    ///     字段列表
    /// </summary>
    public List<Field> Fields { get; set; } = [];

    /// <summary>
    ///     显示实体信息
    /// </summary>
    public void Display()
    {
        // Spectre Console - 控制台输出
        var table = new Table { Title = new TableTitle($"Entity: {EntityName}") };
        table.Expand();
        // 表信息
        AnsiConsole.Live(table).Start(ctx =>
        {
            table.AddColumn(new TableColumn(new Text(nameof(TableName), new Style(Color.Blue))));
            ctx.Refresh();
            Thread.Sleep(500);

            table.AddColumn(new TableColumn(new Text(nameof(EntityName), new Style(Color.Blue))));
            ctx.Refresh();
            Thread.Sleep(500);

            table.AddColumn(new TableColumn(new Text(nameof(Comment), new Style(Color.Blue))));
            ctx.Refresh();
            Thread.Sleep(500);

            table.AddRow(TableName!, Comment!, EntityName!);
        });

        Thread.Sleep(500);

        // 列信息
        var fieldsTable = new Table { Title = new TableTitle("Fields") };
        fieldsTable.Expand();
        AnsiConsole.Live(fieldsTable).Start(ctx =>
        {
            fieldsTable.AddColumn(new TableColumn(new Text(nameof(Field.Name), new Style(Color.Green))));
            ctx.Refresh();
            Thread.Sleep(500);

            fieldsTable.AddColumn(new TableColumn(new Text(nameof(Field.Type), new Style(Color.Green))));
            ctx.Refresh();
            Thread.Sleep(500);

            fieldsTable.AddColumn(
                new TableColumn(new Text(nameof(Field.Length), new Style(Color.Green))));
            ctx.Refresh();
            Thread.Sleep(500);

            fieldsTable.AddColumn(
                new TableColumn(new Text(nameof(Field.IsPrimaryKey), new Style(Color.Green))));
            ctx.Refresh();
            Thread.Sleep(500);

            fieldsTable.AddColumn(
                new TableColumn(new Text(nameof(Field.Mandatory), new Style(Color.Green))));
            ctx.Refresh();
            Thread.Sleep(500);

            fieldsTable.AddColumn(
                new TableColumn(new Text(nameof(Field.Comment), new Style(Color.Green))));
            ctx.Refresh();
            Thread.Sleep(500);

            foreach (var field in Fields)
            {
                fieldsTable.AddRow(field.Name!, field.Type!, field.Length!, field.IsPrimaryKey.ToString(),
                    field.Mandatory.ToString(), field.Comment!);
                ctx.Refresh();
                Thread.Sleep(500);
            }

            fieldsTable.Caption = new TableTitle($"Total Fields: {Fields.Count}");
        });
    }
}