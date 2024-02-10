using Notes.Models;

namespace Notes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{
    /// <summary>
    /// 笔记文件路径，从页面查询属性获取
    /// 修改时，调用方法加载笔记内容
    /// </summary>
    public string ItemId
    {
        set { LoadNote(value); }
    }

    public NotePage()
    {
        // InitializeComponent() 方法的作用是：
        // 读取 XAML 和初始化 XAML 中定义的对象
        InitializeComponent();
        // 读取笔记内容，显示到 Editor 控件上
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    /// <summary>
    /// 加载笔记内容
    /// </summary>
    /// <param name="fileName">文件名称</param>
    private void LoadNote(string fileName)
    {
        Note note = new()
        {
            FileName = fileName
        };

        if (File.Exists(fileName))
        {
            note.Date = File.GetCreationTime(fileName);
            note.Text = File.ReadAllText(fileName);
        }

        // 设置绑定上下午
        BindingContext = note;
    }

    /// <summary>
    /// 保存笔记
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SaveNote(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            File.WriteAllText(note.FileName, TextEditor.Text);
        }

        // 回到上一页
        await Shell.Current.GoToAsync("..");
    }

    /// <summary>
    /// 删除笔记：
    /// 1. 删除笔记文件
    /// 2. 清空 Editor 控件中的内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void DeleteNote(object sender, EventArgs e)
    {
        if (BindingContext is Note note)
        {
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }
        }

        TextEditor.Text = string.Empty;

        // 回到上一页
        await Shell.Current.GoToAsync("..");
    }
}