using System.Windows;
using System.Windows.Controls;

namespace Wpf.Dp.PropertyChangeCallback.Controls;

/// <summary>
/// 托盘控件
/// </summary>
public partial class TrayControl : UserControl
{
    public TrayControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 格子大小
    /// </summary>
    public int Size
    {
        get => (int)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
        nameof(Size), typeof(int), typeof(TrayControl),
        new PropertyMetadata(60, OnSizePropertyChangedCallback)
    );

    /// <summary>
    /// 格子大小变化回调
    /// </summary>
    /// <param name="d"></param>
    /// <param name="e"></param>
    private static void OnSizePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var trayControl = d as TrayControl;
        trayControl?.Initialize();
    }

    /// <summary>
    /// 格子数量
    /// </summary>
    public int Count
    {
        get => (int)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
        nameof(Count), typeof(int), typeof(TrayControl),
        new PropertyMetadata(0, OnCountPropertyChangedCallback, OnCountCoerceValueCallback)
    );

    /// <summary>
    /// 格子数量强转回调，先于 <see cref="OnCountPropertyChangedCallback"/> 执行
    /// </summary>
    /// <param name="d">依赖对象</param>
    /// <param name="basevalue">基础值</param>
    /// <returns>格子数量</returns>
    private static object OnCountCoerceValueCallback(DependencyObject d, object basevalue)
    {
        var count = (int)basevalue;
        if (count == 10)
        {
            return count * 10;
        }

        return basevalue;
    }

    /// <summary>
    /// 格子数量变化回调
    /// </summary>
    /// <param name="d"></param>
    /// <param name="e"></param>
    private static void OnCountPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var trayControl = d as TrayControl;
        trayControl?.Initialize();
    }

    /// <summary>
    /// 当前选中的格子数量
    /// </summary>
    public int SelectedCount
    {
        get => (int)GetValue(SelectedCountProperty);
        set => SetValue(SelectedCountProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SelectedCountProperty = DependencyProperty.Register(
        nameof(SelectedCount), typeof(int), typeof(TrayControl), new PropertyMetadata(0)
    );

    /// <summary>
    /// 当前选中的格子
    /// </summary>
    public List<CheckBox> SelectedItems
    {
        get => (List<CheckBox>)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }

    // Using a DependencyProperty as the backing store for MyProperty.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
        nameof(SelectedItems), typeof(List<CheckBox>), typeof(TrayControl),
        new PropertyMetadata(new List<CheckBox>())
    );

    /// <summary>
    /// 初始化
    /// </summary>
    private void Initialize()
    {
        SelectedCount = 0;
        Container.Children.Clear();
        SelectedItems.Clear();

        if (Count <= 0)
        {
            return;
        }

        for (var i = 0; i < Count; i++)
        {
            var checkBox = new CheckBox
            {
                Style = Application.Current.Resources["CheckBoxDishStyle"] as Style,
                Width = Size,
                Height = Size,
                Tag = new Point(i * 10, Size + i * 2),
                Name = $"_{i.ToString()}"
            };
            // 复选框选中时，添加格子
            checkBox.Checked += (_, _) =>
            {
                SelectedCount++;
                SelectedItems.Add(checkBox);
            };
            // 复选框取消选中时，删除格子
            checkBox.Unchecked += (_, _) =>
            {
                SelectedCount--;
                SelectedItems.Remove(checkBox);
            };
            
            Container.Children.Add(checkBox);
        }
    }
}