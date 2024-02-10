using System.Globalization;
using Notes.Models;

namespace Notes.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        TimeLabel.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// 按钮点击事件，使用系统默认浏览器跳转到某个网页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is About about)
        {
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}