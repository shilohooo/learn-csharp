using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Notes.Models;

namespace Notes.ViewModels;

/// <summary>
/// 笔记详情页面视图模型
/// </summary>
public class NoteViewModel : ObservableObject, IQueryAttributable
{
    /// <summary>
    /// 笔记详情
    /// </summary>
    private Note _note;

    /// <summary>
    /// 笔记唯一标识
    /// 属性 => 语法用于创建只读属性
    /// </summary>
    public string Identifier => _note.FileName;

    /// <summary>
    /// 笔记内容
    /// </summary>
    public string Text
    {
        get => _note.Text;
        set
        {
            if (_note.Text == value)
            {
                return;
            }

            _note.Text = value;
            // 通知属性值已更改
            // 任何绑定了该属性的界面都能收到通知
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 笔记最后修改时间
    /// </summary>
    public DateTime Date => _note.Date;

    /// <summary>
    /// 保存笔记命令
    /// </summary>
    public ICommand SaveCommand { get; private set; }

    /// <summary>
    /// 删除笔记命令
    /// </summary>
    public ICommand DeleteCommand { get; private set; }

    public NoteViewModel()
    {
        _note = new Note();
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    public NoteViewModel(Note note)
    {
        _note = note;
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    /// <summary>
    /// 保存笔记
    /// </summary>
    private async Task Save()
    {
        _note.Date = DateTime.Now;
        _note.Save();
        await Shell.Current.GoToAsync($"..?saved={_note.FileName}");
    }

    /// <summary>
    /// 删除笔记
    /// </summary>
    private async Task Delete()
    {
        _note.Delete();
        await Shell.Current.GoToAsync($"..?deleted={_note.FileName}");
    }

    /// <summary>
    /// 从查询参数中获取笔记
    /// 当实现了 <see cref="IQueryAttributable"/> 接口时，
    /// 页面查询参数将自动传递给 <see cref="ApplyQueryAttributes"/> 方法
    /// </summary>
    /// <param name="query">查询参数</param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("load", out var fileNameParam))
        {
            return;
        }

        var fileName = fileNameParam.ToString();
        if (fileName is null)
        {
            return;
        }

        _note = Note.LoadNote(fileName);
        RefreshProperties();
    }

    /// <summary>
    /// 重新加载笔记
    /// </summary>
    public void Reload()
    {
        _note = Note.LoadNote(_note.FileName);
        RefreshProperties();
    }

    /// <summary>
    /// 刷新属性
    /// </summary>
    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Date));
    }
}