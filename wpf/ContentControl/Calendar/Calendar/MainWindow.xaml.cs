using System.Windows;

namespace Calendar;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowSelectedDates(object sender, RoutedEventArgs e)
    {
        var selectedDates = Calendar.SelectedDates;
        foreach (var dateTime in selectedDates)
        {
            Console.WriteLine(dateTime);
        }

        // 多选情况下，SelectedDate 是第一个选中的日期
        var selectedDate = Calendar.SelectedDate;
        MessageBox.Show($"当前选择了 {selectedDates.Count} 个日期，第一个选中日期为：{selectedDate}");
    }
}