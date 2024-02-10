using Notes.Models;

namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();
        // 设置绑定上下文
        BindingContext = new Models.AllNotes();
    }

    /// <summary>
    /// 页面显示后自动调用该方法，比如说跳转到该页面时
    /// </summary>
    protected override void OnAppearing()
    {
        // 加载所有笔记
        if (BindingContext is AllNotes allNotes)
        {
            allNotes.LoadNotes();
        }
    }

    /// <summary>
    /// 添加笔记
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void AddNote(object sender, EventArgs e)
    {
        // 导航到指定页面
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    /// <summary>
    /// 选择笔记
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // 获取 Note 模型类实例
            var note = (Note)e.CurrentSelection[0];
            // 跳转到笔记页面并带上当前选择的笔记文件的路径："NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");
            // 取消选择
            notesCollection.SelectedItem = null;
        }
    }
}