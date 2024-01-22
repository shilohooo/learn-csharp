using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf.Navigation.NavigationWindow.Pages;

public partial class Page1 : Page
{
    public Page1()
    {
        InitializeComponent();
        TimeTextBlock.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// 跳转到 Page2
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToPage2(object sender, MouseButtonEventArgs e)
    {
        // 第一种导航方式
        // var navigationService = NavigationService.GetNavigationService(this);
        // navigationService?.Navigate(new Uri("/Pages/Page2.xaml", UriKind.Relative));

        // 第二种导航方式：Page2被实例化后，在每次前进或后端的操作中，Page2中的内容不会发生改变
        // 这是因为导航日志记录了当前页面
        
        // 这个对象最终会进入导航日志容器中，导航日志可以暂存页面实例
        var page2 = new Page2();
        NavigationService?.Navigate(page2);

        // 第三种导航方式
        // NavigationService?.Navigate(new Uri("/Pages/Page2.xaml", UriKind.Relative));
    }
}