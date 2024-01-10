namespace Wpf.Template.ListBox.TemplateStyle.Model;

/// <summary>
/// 句子实体
/// </summary>
public class Sentence : ObservableObject
{
    /// <summary>
    /// backing field of <see cref="Content"/>
    /// </summary>
    private string _content;

    /// <summary>
    /// 内容
    /// </summary>
    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            OnPropertyChanged();
        }
    }
}