namespace Maui.Xaml.Fundamentals;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        // 调用该方法初始化 XAML 文件中定义的所有对象
        // 并将事件处理器附加到 XAML 文件的事件集中
        InitializeComponent();
    }

    /// <summary>
    /// 页面跳转
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void GoToAsync(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HelloXamlPage());
    }
}