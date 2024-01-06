using System.Collections.ObjectModel;
using Style.MultiDataTrigger.Model;

namespace Style.MultiDataTrigger.ViewModel;

/// <summary>
/// 主视图 ViewModel
/// </summary>
public class MainViewModel : ObservableObject
{
    /// <summary>
    /// 人员字段
    /// </summary>
    private Person _person;

    /// <summary>
    /// 人员属性
    /// </summary>
    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            base.OnPropertyChanged();
        }
    }

    /// <summary>
    /// 人员属性集合
    /// </summary>
    public ObservableCollection<Person> Persons { get; set; } = [];
}