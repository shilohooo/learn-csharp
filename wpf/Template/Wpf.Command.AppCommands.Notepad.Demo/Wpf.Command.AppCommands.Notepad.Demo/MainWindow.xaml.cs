using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace Wpf.Command.AppCommands.Notepad.Demo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true;
    }

    /// <summary>
    /// 打开文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OpenCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "文本文档(.txt)|*.txt",
            Multiselect = false
        };
        var selectedResult = openFileDialog.ShowDialog();
        if (selectedResult is null || !selectedResult.Value)
        {
            MessageBox.Show("文件打开失败");
            return;
        }

        // 将文本文件的内容全部读取到文本框中
        TextBox.Text = File.ReadAllText(openFileDialog.FileName);
    }

    private void CutCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        // 选中内容后才能剪切
        e.CanExecute = TextBox is not null && TextBox.SelectedText.Length > 0;
    }

    /// <summary>
    /// 剪切文本
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CutCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        // 调用文本框的剪切方法
        TextBox.Cut();
    }

    private void PasteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        // 剪切板有内容，才能粘贴
        e.CanExecute = Clipboard.ContainsText();
    }

    /// <summary>
    /// 粘贴内容
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PasteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        // 把剪切板的内容粘贴追加到文本框中
        TextBox.Paste();
    }

    private void SaveCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        // 文本框输入了内容才需要保存
        e.CanExecute = TextBox is not null && TextBox.Text.Length > 0;
    }

    /// <summary>
    /// 保存文件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        // 保存文件，或另存为指定文件
        var saveFileDialog = new SaveFileDialog
        {
            Filter = "文本文档(.txt)|*.txt"
        };

        if (saveFileDialog.ShowDialog() is true)
        {
            // 将文本框的内容写入文件
            File.WriteAllText(saveFileDialog.FileName, TextBox.Text);
        }
    }
}