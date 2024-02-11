using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Notes.Models;
using Notes.Views;

namespace Notes.ViewModels;

/// <summary>
/// 笔记列表页面视图模型
/// </summary>
public class NotesViewModel : IQueryAttributable
{
    /// <summary>
    /// 笔记列表
    /// </summary>
    public ObservableCollection<NoteViewModel> AllNotes { get; set; }

    /// <summary>
    /// 新建笔记命令
    /// </summary>
    public ICommand NewCommand { get; set; }

    /// <summary>
    /// 选择笔记命令
    /// </summary>
    public ICommand SelectNoteCommand { get; set; }

    public NotesViewModel()
    {
        var notes = Note.LoadNotes()
            .Select(n => new NoteViewModel(n));
        AllNotes = new ObservableCollection<NoteViewModel>(notes);

        NewCommand = new AsyncRelayCommand(NewNoteAsync);
        // 命令可以有一个参数，在命令调用时提供该参数
        SelectNoteCommand = new AsyncRelayCommand<NoteViewModel>(SelectNoteAsync);
    }

    /// <summary>
    /// 跳转到新增笔记页面
    /// </summary>
    private async Task NewNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    /// <summary>
    /// 选择某个笔记，跳转到笔记编辑页面
    /// </summary>
    /// <param name="noteViewModel">笔记详情页视图模型</param>
    private async Task SelectNoteAsync(NoteViewModel? noteViewModel)
    {
        if (noteViewModel != null)
        {
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?load={noteViewModel.Identifier}");
        }
    }

    /// <summary>
    /// 接受页面参数，执行添加或移除笔记数据操作
    /// </summary>
    /// <param name="query">页面查询参数</param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("deleted", out var deletedParam))
        {
            var deleteFileName = deletedParam.ToString();
            if (deleteFileName is null)
            {
                return;
            }

            var matchedNote = AllNotes.FirstOrDefault(n => n.Identifier == deleteFileName);

            if (matchedNote != null)
            {
                AllNotes.Remove(matchedNote);
            }
        }
        else if (query.TryGetValue("saved", out var savedParam))
        {
            var savedNoteId = savedParam.ToString();
            var matchedNote = AllNotes.FirstOrDefault(n => n.Identifier == savedNoteId);
            if (matchedNote is not null)
            {
                // 更新笔记
                matchedNote.Reload();
                // 将笔记放到首位
                AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
            }
            else if (savedNoteId is not null)
            {
                // 新增笔记到首位
                AllNotes.Insert(0, new NoteViewModel(Note.LoadNote(savedNoteId)));
            }
        }
    }
}