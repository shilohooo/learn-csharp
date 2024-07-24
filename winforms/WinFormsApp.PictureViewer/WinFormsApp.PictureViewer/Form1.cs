namespace WinFormsApp.PictureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ѡ��һ��ͼ�������ʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void HandleShowPicture(object sender, EventArgs e)
        {
            // ���ļ�ѡ��Ի������û�ѡ���ļ�
            // ѡ����ļ�֮�󣬵��ȷ�������û�ѡ���ͼƬ��ʾ�� PictureBox �ؼ���
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// �����ǰ��ʾ��ͼƬ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClearPicture(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        /// <summary>
        /// ����ͼƬ����ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleSetPictureBgColor(object sender, EventArgs e)
        {
            // ������ɫѡ��Ի������û�ѡ��ͼƬ�ı���ɫ
            // ���û���� OK ���޸� PictureBox �ؼ��ı���ɫΪ�û�ѡ�����ɫ
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        /// <summary>
        /// �رճ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleClose(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlePictureStretch(object sender, EventArgs e)
        {
            // ����û���ѡ�� stretch ��ѡ����ͼƬ�ĳߴ�ģʽ��Ϊ����ģʽ
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                return;
            }

            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
