namespace WinFormsApp.PictureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择一张图标进行显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void HandleShowPicture(object sender, EventArgs e)
        {
            // 打开文件选择对话框，让用户选择文件
            // 选择好文件之后，点击确定，把用户选择的图片显示到 PictureBox 控件中
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 清除当前显示的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClearPicture(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        /// <summary>
        /// 设置图片背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSetPictureBgColor(object sender, EventArgs e)
        {
            // 弹出颜色选择对话框让用户选择图片的背景色
            // 当用户点击 OK 后，修改 PictureBox 控件的背景色为用户选择的颜色
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClose(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 图片拉伸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlePictureStretch(object sender, EventArgs e)
        {
            // 如果用户勾选了 stretch 复选框，则将图片的尺寸模式改为拉伸模式
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return;
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
