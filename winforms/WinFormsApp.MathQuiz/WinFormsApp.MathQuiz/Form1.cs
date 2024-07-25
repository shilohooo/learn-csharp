using System.Media;

namespace WinFormsApp.MathQuiz
{
    public partial class Form1 : Form
    {

        // 用于创建随机数的 Random 对象
        private readonly Random _random = new();

        /// <summary>
        /// 加数
        /// </summary>
        private int _addend1;
        private int _addend2;

        /// <summary>
        /// 减数
        /// </summary>
        private int _minuend;

        /// <summary>
        /// 被减数
        /// </summary>
        private int _subtrahend;

        /// <summary>
        /// 乘方
        /// </summary>
        private int _multiplicand;

        /// <summary>
        /// 乘数
        /// </summary>
        private int _multiplier;

        /// <summary>
        /// 除数
        /// </summary>
        private int _dividend;

        /// <summary>
        /// 被除数
        /// </summary>
        private int _divisor;

        /// <summary>
        /// 测验剩余时间
        /// </summary>
        private int _timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 开始测试按钮点击事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleStartQuiz(object sender, EventArgs e)
        {
            StartTheQuiz();
            startBtn.Enabled = false;
        }

        /// <summary>
        /// 启动测验，并启动计时器
        /// </summary>
        public void StartTheQuiz()
        {
            // 生成两个随机数，大小在 0 到 50 之间
            _addend1 = _random.Next(51);
            _addend2 = _random.Next(51);

            // 将两个随机数显示到 Label 控件中
            plusLeftLabel.Text = _addend1.ToString();
            plusRightLabel.Text = _addend2.ToString();

            // 初始化计算结果为 0
            sum.Value = 0;

            _minuend = _random.Next(1, 101);
            _subtrahend = _random.Next(1, _minuend);
            minusLeftLabel.Text = _minuend.ToString();
            minusRightLabel.Text = _subtrahend.ToString();
            difference.Value = 0;

            _multiplicand = _random.Next(2, 11);
            _multiplier = _random.Next(2, 11);
            timesLeftLabel.Text = _multiplicand.ToString();
            timesRightLabel.Text = _multiplier.ToString();
            product.Value = 0;


            _divisor = _random.Next(2, 11);
            int temp = _random.Next(2, 11);
            _dividend = _divisor * temp;
            dividedLeftLabel.Text = _dividend.ToString();
            dividedRightLabel.Text = _divisor.ToString();
            quotient.Value = 0;

            // 启动计时器，答题时间设置为30秒
            _timeLeft = 30;
            timeLeftLabel.Text = "30 seconds";
            timer1.Start();
        }

        /// <summary>
        /// 计时器事件回调处理，每秒触发一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandlerTimerTick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // 停止计时器
                timer1.Stop();
                // 提示答题正确
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                // 开始测验按钮恢复为可点击状态
                startBtn.Enabled = true;
                return;
            }

            if (_timeLeft > 0)
            {
                // 还有剩余时间，继续倒计时
                _timeLeft--;
                timeLeftLabel.Text = $"{_timeLeft} seconds";
                // 还剩5秒，显示剩余时间的 Label 控件背景色改为红色
                if (_timeLeft <= 5)
                {
                    timeLeftLabel.BackColor = Color.Red;
                }
                return;
            }

            // 时间到了还没答对，停止计时器，然后显示正确的答案
            timer1.Stop();
            timeLeftLabel.Text = "Time's up!";
            MessageBox.Show("You didn't finish in time", "Sorry!");
            sum.Value = _addend1 + _addend2;
            difference.Value = _minuend - _subtrahend;
            product.Value = _multiplicand * _multiplier;
            quotient.Value = _dividend / _divisor;
            // 开始测验按钮恢复为可点击状态
            startBtn.Enabled = true;

        }

        /// <summary>
        /// 检查答案
        /// <returns>答案正确返回 true，否则返回 false</returns>
        /// </summary>
        public bool CheckTheAnswer()
        {
            return (_addend1 + _addend2 == sum.Value)
                && (_minuend - _subtrahend == difference.Value)
                && (_multiplicand * _multiplier == product.Value)
                && (_dividend / _divisor == quotient.Value);
        }

        /// <summary>
        /// 答案输入框 Enter 事件处理
        /// </summary>
        /// <param name="sender">触发事件的对象</param>
        /// <param name="e">事件参数</param>
        private void HandleAnswerEnter(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown answerBox)
            {
                return;
            }

            // 选中答案输入框文本
            var lengthOfAnswer = answerBox.Value.ToString().Length;
            answerBox.Select(0, lengthOfAnswer);
        }

        /// <summary>
        /// 值改变事件处理，答对播放声音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleValueChanged(object sender, EventArgs e)
        {
            if (sender is not NumericUpDown answerBox)
            {
                return;
            }

            // 输入的答案正确就播放声音
            switch (answerBox.Name)
            {
                case "sum":
                    if (answerBox.Value == _addend1 + _addend2)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    break;
                case "difference":
                    if (answerBox.Value == _minuend - _subtrahend)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    break;
                case "product":
                    if (answerBox.Value == _multiplicand * _multiplier)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    break;
                case "quotient":
                    if (answerBox.Value == _dividend / _divisor)
                    {
                        SystemSounds.Asterisk.Play();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
