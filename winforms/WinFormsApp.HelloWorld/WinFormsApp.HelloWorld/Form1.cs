namespace WinFormsApp.HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按钮点击事件回调
        /// </summary>
        /// <param name="sender">事件发送对象</param>
        /// <param name="e">事件参数</param>
        private void ButtonClickCallback(object sender, EventArgs e)
        {
            lb1HelloWorld.Text = @"Hello World:)";
        }
    }
}
