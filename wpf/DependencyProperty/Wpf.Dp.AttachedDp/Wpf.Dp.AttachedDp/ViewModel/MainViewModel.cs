using Wpf.Dp.AttachedDp.Model;

namespace Wpf.Dp.AttachedDp.ViewModel;

/// <summary>
/// 主窗体 ViewModel
/// </summary>
public class MainViewModel : ObservableObject
{
    #region PrivateFields

    /// <summary>
    /// backing field of <see cref="Person"/>
    /// </summary>
    private Person _person = new();

    #endregion

    #region PublicProperties

    /// <summary>
    /// 人员信息
    /// </summary>
    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            OnPropertyChanged();
        }
    }

    #endregion
}