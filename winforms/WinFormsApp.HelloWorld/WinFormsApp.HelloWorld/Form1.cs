namespace WinFormsApp.HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ��ť����¼��ص�
        /// </summary>
        /// <param name="sender">�¼����Ͷ���</param>
        /// <param name="e">�¼�����</param>
        private void ButtonClickCallback(object sender, EventArgs e)
        {
            lb1HelloWorld.Text = @"Hello World:)";
        }
    }
}
