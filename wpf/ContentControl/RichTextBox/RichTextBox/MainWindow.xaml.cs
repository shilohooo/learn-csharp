using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace RichTextBox;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowRichTextBoxContent(object sender, RoutedEventArgs e)
    {
        // FlowDocument类有两个属性，分别ContentStart和ContentEnd，表示文字内容的开始和结束。
        var textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
        MessageBox.Show($"富文本框中的内容为：{textRange.Text}");

        // 添加段落到富文本框中
        var paragraph = new Paragraph();
        var run = new Run($"当前时间为：{DateTime.Now}")
        {
            Foreground = Brushes.HotPink
        };
        paragraph.Inlines.Add(run);
        RichTextBox.Document.Blocks.Add(paragraph);
    }
}