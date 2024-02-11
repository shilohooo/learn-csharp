using Microsoft.Maui.Controls;
using Notes.Views;

namespace Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // 注册页面路由，所有需要通过导航跳转的页面都需要注册
            // 定义在 TabBar 控件中的页面将自动注册为路由
            // RegisterRoute() 方法的第一个参数是页面 URL，比如这里为："NotePage"
            // 第二个参数是页面的类型
            Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
        }
    }
}