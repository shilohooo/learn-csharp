namespace Maui.Xaml.Fundamentals;

public partial class HelloXamlPage : ContentPage
{
	public HelloXamlPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// 滑块值改变回调
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // 使用 XAML 中定义的控件名称引用该对象 SliderValueLabel
        // 控件名称通过 x:Name 属性定义
        // ToString("F$precision") 可以格式化为指定精度的数值
        if (SliderValueLabel is null)
        {
            return;
        }

        SliderValueLabel.Text = e.NewValue.ToString("F1");
    }

    private async void DisplayAlertMsg(object sender, EventArgs e)
    {
        if (sender is Button)
        {
			await DisplayAlert("标题!", "对话框内容", "右侧按钮文字");
        }
    }
}