using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.Transform.SimpleImageViewer.ViewModel;

namespace Wpf.Transform.SimpleImageViewer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region PrivateFields

    /// <summary>
    /// 视图模型
    /// </summary>
    private MainViewModel _vm = new();

    /// <summary>
    /// 鼠标是否按下
    /// </summary>
    private bool _isMouseDown;

    /// <summary>
    /// 鼠标位置
    /// </summary>
    private Point _mousePoint;

    /// <summary>
    /// 平移转换
    /// </summary>
    private readonly TranslateTransform _translateTransform = new();

    /// <summary>
    /// 缩放转换
    /// </summary>
    private readonly ScaleTransform _scaleTransform = new();

    /// <summary>
    /// 转换组
    /// </summary>
    private readonly TransformGroup _transformGroup = new();

    #endregion

    #region Constructors

    public MainWindow()
    {
        InitializeComponent();

        Loaded += (_, _) =>
        {
            if (DataContext is not MainViewModel mainViewModel)
            {
                return;
            }

            // 计算原始的图片放大倍率和平移位置
            _vm = mainViewModel;
            _transformGroup.Children.Add(_translateTransform);
            _transformGroup.Children.Add(_scaleTransform);
            Image.RenderTransform = _transformGroup;
            var scale = Math.Min(
                Canvas.ActualWidth / Image.ActualWidth, Canvas.ActualHeight / Image.ActualHeight
            );
            _scaleTransform.ScaleX = scale;
            _scaleTransform.ScaleY = scale;
            _translateTransform.X = (Canvas.ActualWidth - Image.ActualWidth * scale) / 2;
        };
    }

    #endregion

    #region ControlEvents

    /// <summary>
    /// 鼠标滚动时计算缩放和平移
    /// </summary>
    /// <remark>
    /// 需要注意的是，进行缩放时需要拿到TransformGroup 的反函数并转换当前鼠标坐标，
    /// 最后缩放结束后再设置平移位置，并再次取反。这样才能实现以鼠标坐标为中心对图片进行缩放。
    /// </remark>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_OnMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var delta = e.Delta;
        var scale = delta * 0.001;
        var point = e.GetPosition(Canvas);
        _vm.X = point.X;
        _vm.Y = point.Y;
        _vm.Delta = delta;

        if (_scaleTransform.ScaleX + scale < 0.1)
        {
            return;
        }

        // 还原图片大小
        if (_transformGroup.Inverse is null)
        {
            return;
        }

        var inversePoint = _transformGroup.Inverse.Transform(point);
        _scaleTransform.ScaleX += scale;
        _scaleTransform.ScaleY += scale;
        _translateTransform.X = -(inversePoint.X * _scaleTransform.ScaleX - point.X);
        _translateTransform.Y = -(inversePoint.Y * _scaleTransform.ScaleY - point.Y);
    }

    /// <summary>
    /// 鼠标平移时设置平移参数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
    {
        var point = e.GetPosition(Canvas);
        _vm.X = point.X;
        _vm.Y = point.Y;

        if (!_isMouseDown)
        {
            return;
        }

        _translateTransform.X += point.X - _mousePoint.X;
        _translateTransform.Y += point.Y - _mousePoint.Y;
        _mousePoint = point;
    }

    /// <summary>
    /// 鼠标抬起时结束操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _isMouseDown = false;
    }

    /// <summary>
    /// 按下鼠标时设置标志位
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Canvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _isMouseDown = true;
        _mousePoint = e.GetPosition(Canvas);
    }

    #endregion
}