using Wpf.Transform.SimpleImageViewer.Mvvm;

namespace Wpf.Transform.SimpleImageViewer.ViewModel;

/// <summary>
/// 主窗体视图模型
/// </summary>
public class MainViewModel : ObservableObject
{
    #region PrivateFields

    /// <summary>
    /// X轴
    /// </summary>
    private double _x;

    /// <summary>
    /// Y轴
    /// </summary>
    private double _y;

    /// <summary>
    /// 变数量
    /// </summary>
    private double _delta;

    #endregion

    #region PublicProperties

    /// <summary>
    /// X轴属性
    /// </summary>
    public double X
    {
        get => _x;
        set
        {
            _x = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Y轴属性
    /// </summary>
    public double Y
    {
        get => _y;
        set
        {
            _y = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 变数量属性
    /// </summary>
    public double Delta
    {
        get => _delta;
        set
        {
            _delta = value;
            OnPropertyChanged();
        }
    }

    #endregion
}