using System.Media;

namespace WinFormsApp.MatchGame;

public partial class Form1 : Form
{
    // 产生随机数选中随机的图标
    private readonly Random _random = new();

    // 字母列表，在字体为 Webdings 时会显示为图标
    private List<string> _icons = [
        "!", "!", "N", "N", ",", ",", "k", "k",
        "b", "b", "v", "v", "w", "w", "z", "z"
    ];

    /// <summary>
    /// 第一次点击的 Label 控件
    /// </summary>
    private Label? _firstClickLable;

    /// <summary>
    /// 第二次点击的 Label 控件
    /// </summary>
    private Label? _secondClickLable;

    public Form1()
    {
        InitializeComponent();
        AssignIconsToSquares();
    }

    /// <summary>
    /// 随机分配图标到表格上的 Label 控件中
    /// </summary>
    private void AssignIconsToSquares()
    {
        foreach (var control in tableLayoutPanel1.Controls)
        {
            if (control is not Label label)
            {
                continue;
            }

            var randomNum = _random.Next(_icons.Count);
            label.Text = _icons[randomNum];
            // 隐藏图标
            label.ForeColor = label.BackColor;
            _icons.RemoveAt(randomNum);
        }
    }

    /// <summary>
    /// Label 控件点击事件：显示图标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleLabelClick(object sender, EventArgs e)
    {
        if (timer1.Enabled)
        {
            return;
        }

        if (sender is not Label label)
        {
            return;
        }

        // 将 Label 控件的文本颜色改为黑色
        if (label.ForeColor == Color.Black)
        {
            return;
        }

        if (_firstClickLable is null)
        {
            _firstClickLable = label;
            _firstClickLable.ForeColor = Color.Black;
            return;
        }

        // 走到这里，点击的应该是第二个图标
        _secondClickLable = label;
        _secondClickLable.ForeColor = Color.Black;

        CheckForWinner();

        // 如果点击的图标一样，就不用启动计时器了
        if (_firstClickLable.Text == _secondClickLable.Text)
        {
            _firstClickLable = null;
            _secondClickLable = null;
            return;
        }

        // 启动计时器
        timer1.Start();
    }

    /// <summary>
    /// 计时器触发回调，每750毫秒触发一次
    /// 点击了两个不一样的图标时，就会启动计时器，然后在750毫秒后隐藏图标
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void HandleTimerTick(object sender, EventArgs e)
    {
        timer1.Stop();
        // 隐藏图标
        _firstClickLable!.ForeColor = _firstClickLable.BackColor;
        _secondClickLable!.ForeColor = _secondClickLable.BackColor;
        // 重置引用
        _firstClickLable = null;
        _secondClickLable = null;
    }

    /// <summary>
    /// 检查是否胜利
    /// </summary>
    private void CheckForWinner()
    {
        foreach (var control in tableLayoutPanel1.Controls)
        {
            if (control is not Label label)
            {
                continue;
            }

            // 检查是否选对两个一样的图标
            if (label.ForeColor == label.BackColor)
            {
                return;
            }
        }

        SystemSounds.Beep.Play();
        MessageBox.Show("You matched all the icons!", "Congratulations");
        Close();
    }
}
