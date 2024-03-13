namespace WinFormsApp.HelloWorld
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            lb1HelloWorld.Text = @"Hello World:)";
        }
    }
}
