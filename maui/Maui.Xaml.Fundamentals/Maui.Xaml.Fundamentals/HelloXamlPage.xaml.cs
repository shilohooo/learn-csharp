namespace Maui.Xaml.Fundamentals;

public partial class HelloXamlPage : ContentPage
{
	public HelloXamlPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// ����ֵ�ı�ص�
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // ʹ�� XAML �ж���Ŀؼ��������øö��� SliderValueLabel
        // �ؼ�����ͨ�� x:Name ���Զ���
        // ToString("F$precision") ���Ը�ʽ��Ϊָ�����ȵ���ֵ
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
			await DisplayAlert("����!", "�Ի�������", "�Ҳఴť����");
        }
    }
}