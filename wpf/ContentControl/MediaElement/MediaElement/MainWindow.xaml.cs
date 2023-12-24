using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;

namespace MediaElement;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _file = string.Empty;

    public MainWindow()
    {
        InitializeComponent();
        // 更新播放进度
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000)
        };
        timer.Tick += (_, _) =>
        {
            var position = MediaElement.Position;
            ProgressBar.Value = position.TotalMilliseconds;
            if (!MediaElement.NaturalDuration.HasTimeSpan)
            {
                return;
            }

            // 显示播放剩余时长：时:分:秒
            VideoDuration.Text = MediaElement.NaturalDuration.TimeSpan.Subtract(position).ToString(@"hh\:mm\:ss");
        };
        timer.Start();
    }

    /// <summary>
    /// 选择媒体文件用于播放
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OpenMediaFile(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "视频文件(.mp4)|*.mp4",
            Multiselect = true
        };
        var result = openFileDialog.ShowDialog();
        if (result is false)
        {
            return;
        }

        _file = openFileDialog.FileName;
        MediaElement.MediaOpened += OnMediaOpened;
        MediaElement.Source = new Uri(_file);
        Title = _file;
        TextBlock.Text = _file;
    }

    /// <summary>
    /// 媒体文件打开后的回调
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void OnMediaOpened(object sender, RoutedEventArgs e)
    {
        // 设置播放进度条总长度
        if (MediaElement.NaturalDuration.HasTimeSpan is false)
        {
            return;
        }

        ProgressBar.Maximum = MediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
    }

    /// <summary>
    /// 播放媒体文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Play(object sender, RoutedEventArgs e)
    {
        MediaElement.Play();
        // 隐藏边框
        Border.Visibility = Visibility.Collapsed;
    }

    /// <summary>
    /// 暂停播放
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void Pause(object sender, RoutedEventArgs e)
    {
        MediaElement.Pause();
    }

    /// <summary>
    /// 快退 10 秒
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void Back10Seconds(object sender, RoutedEventArgs e)
    {
        MediaElement.Position -= TimeSpan.FromSeconds(10);
    }

    /// <summary>
    /// 快进 10 秒
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void Forward10Seconds(object sender, RoutedEventArgs e)
    {
        MediaElement.Position += TimeSpan.FromSeconds(10);
    }

    /// <summary>
    /// 调节音量
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChangeVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        MediaElement.Volume = Slider.Value;
    }
}