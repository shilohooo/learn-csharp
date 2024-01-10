using System.Collections.ObjectModel;
using Wpf.Template.ListBox.TemplateStyle.Model;

namespace Wpf.Template.ListBox.TemplateStyle.ViewModel;

/// <summary>
/// 主窗体视图模型
/// </summary>
public class MainViewModel : ObservableObject
{
    /// <summary>
    /// backing field of <see cref="Sentences"/>
    /// </summary>
    private ObservableCollection<Sentence> _sentences = [];

    /// <summary>
    /// 句子集合
    /// </summary>
    public ObservableCollection<Sentence> Sentences
    {
        get => _sentences;
        set
        {
            _sentences = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        // 添加测试数据
        Sentences.Add(new Sentence { Content = "汉皇重色思倾国，御宇多年求不得。"});
        Sentences.Add(new Sentence { Content = "杨家有女初长成，养在深闺人未识。"});
        Sentences.Add(new Sentence { Content = "天生丽质难自弃，一朝选在君王侧。"});
        Sentences.Add(new Sentence { Content = "回眸一笑百媚生，六宫粉黛无颜色。"});
        Sentences.Add(new Sentence { Content = "春寒赐浴华清池，温泉水滑洗凝脂。"});
        Sentences.Add(new Sentence { Content = "侍儿扶起娇无力，始是新承恩泽时。"});
        Sentences.Add(new Sentence { Content = "云鬓花颜金步摇，芙蓉帐暖度春宵。"});
    }
}