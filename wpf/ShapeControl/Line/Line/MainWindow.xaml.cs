using System.Windows;

namespace Line;

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
            var number = 10;
            Task.Run(() =>
            {
                while (true)
                {
                    if (number == 1)
                    {
                        number = 10;
                    }

                    var copy = number;
                    var action = new Action(() => { FlowLine.StrokeDashOffset = copy; });
                    Application.Current.Dispatcher.BeginInvoke(action);
                    number--;
                    Thread.Sleep(250);
                }
            });
        };
    }
}