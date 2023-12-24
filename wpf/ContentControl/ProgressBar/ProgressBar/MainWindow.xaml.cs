using System.Windows;

namespace ProgressBar;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += (_, _) =>
        {
            Task.Factory.StartNew(() =>
            {
                for (var i = 0; i <= 100; i++)
                {
                    var progress = i;
                    Dispatcher.Invoke(() =>
                    {
                        TextBlock.Text = $"{progress}%";
                        ProgressBar.Value = progress;
                    });

                    Task.Delay(100).Wait();
                }
            });
        };
    }
}