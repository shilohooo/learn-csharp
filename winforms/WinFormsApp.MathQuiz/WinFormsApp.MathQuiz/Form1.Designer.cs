
namespace WinFormsApp.MathQuiz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timeLeftLabel = new Label();
            label2 = new Label();
            plusLeftLabel = new Label();
            plusOepratorLabel = new Label();
            label4 = new Label();
            plusRightLabel = new Label();
            sum = new NumericUpDown();
            difference = new NumericUpDown();
            minusRightLabel = new Label();
            label5 = new Label();
            minusOperatorLabel = new Label();
            minusLeftLabel = new Label();
            product = new NumericUpDown();
            timesRightLabel = new Label();
            label6 = new Label();
            timesOperatorLabel = new Label();
            timesLeftLabel = new Label();
            quotient = new NumericUpDown();
            dividedRightLabel = new Label();
            label7 = new Label();
            dividedOperatorLabel = new Label();
            dividedLeftLabel = new Label();
            startBtn = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)sum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)difference).BeginInit();
            ((System.ComponentModel.ISupportInitialize)product).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quotient).BeginInit();
            SuspendLayout();
            // 
            // timeLeftLabel
            // 
            timeLeftLabel.BorderStyle = BorderStyle.FixedSingle;
            timeLeftLabel.Font = new Font("Microsoft YaHei UI", 16F);
            timeLeftLabel.Location = new Point(272, 9);
            timeLeftLabel.Name = "timeLeftLabel";
            timeLeftLabel.Size = new Size(200, 30);
            timeLeftLabel.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 16F);
            label2.Location = new Point(155, 9);
            label2.Name = "label2";
            label2.Size = new Size(111, 30);
            label2.TabIndex = 1;
            label2.Text = "Time Left";
            // 
            // plusLeftLabel
            // 
            plusLeftLabel.Font = new Font("Microsoft YaHei UI", 18F);
            plusLeftLabel.Location = new Point(50, 75);
            plusLeftLabel.Name = "plusLeftLabel";
            plusLeftLabel.Size = new Size(60, 50);
            plusLeftLabel.TabIndex = 2;
            plusLeftLabel.Text = "?";
            plusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // plusOepratorLabel
            // 
            plusOepratorLabel.Font = new Font("Microsoft YaHei UI", 18F);
            plusOepratorLabel.Location = new Point(116, 75);
            plusOepratorLabel.Name = "plusOepratorLabel";
            plusOepratorLabel.Size = new Size(60, 50);
            plusOepratorLabel.TabIndex = 3;
            plusOepratorLabel.Text = "+";
            plusOepratorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft YaHei UI", 18F);
            label4.Location = new Point(248, 75);
            label4.Name = "label4";
            label4.Size = new Size(60, 50);
            label4.TabIndex = 4;
            label4.Text = "=";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // plusRightLabel
            // 
            plusRightLabel.Font = new Font("Microsoft YaHei UI", 18F);
            plusRightLabel.Location = new Point(182, 75);
            plusRightLabel.Name = "plusRightLabel";
            plusRightLabel.Size = new Size(60, 50);
            plusRightLabel.TabIndex = 5;
            plusRightLabel.Text = "?";
            plusRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sum
            // 
            sum.Font = new Font("Microsoft YaHei UI", 18F);
            sum.Location = new Point(314, 83);
            sum.Name = "sum";
            sum.Size = new Size(100, 38);
            sum.TabIndex = 1;
            sum.ValueChanged += HandleValueChanged;
            sum.Click += HandleAnswerEnter;
            sum.Enter += HandleAnswerEnter;
            // 
            // difference
            // 
            difference.Font = new Font("Microsoft YaHei UI", 18F);
            difference.Location = new Point(314, 133);
            difference.Name = "difference";
            difference.Size = new Size(100, 38);
            difference.TabIndex = 2;
            difference.ValueChanged += HandleValueChanged;
            difference.Click += HandleAnswerEnter;
            difference.Enter += HandleAnswerEnter;
            // 
            // minusRightLabel
            // 
            minusRightLabel.Font = new Font("Microsoft YaHei UI", 18F);
            minusRightLabel.Location = new Point(182, 125);
            minusRightLabel.Name = "minusRightLabel";
            minusRightLabel.Size = new Size(60, 50);
            minusRightLabel.TabIndex = 10;
            minusRightLabel.Text = "?";
            minusRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft YaHei UI", 18F);
            label5.Location = new Point(248, 125);
            label5.Name = "label5";
            label5.Size = new Size(60, 50);
            label5.TabIndex = 9;
            label5.Text = "=";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minusOperatorLabel
            // 
            minusOperatorLabel.Font = new Font("Microsoft YaHei UI", 18F);
            minusOperatorLabel.Location = new Point(116, 125);
            minusOperatorLabel.Name = "minusOperatorLabel";
            minusOperatorLabel.Size = new Size(60, 50);
            minusOperatorLabel.TabIndex = 8;
            minusOperatorLabel.Text = "-";
            minusOperatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minusLeftLabel
            // 
            minusLeftLabel.Font = new Font("Microsoft YaHei UI", 18F);
            minusLeftLabel.Location = new Point(50, 125);
            minusLeftLabel.Name = "minusLeftLabel";
            minusLeftLabel.Size = new Size(60, 50);
            minusLeftLabel.TabIndex = 7;
            minusLeftLabel.Text = "?";
            minusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // product
            // 
            product.Font = new Font("Microsoft YaHei UI", 18F);
            product.Location = new Point(314, 183);
            product.Name = "product";
            product.Size = new Size(100, 38);
            product.TabIndex = 3;
            product.ValueChanged += HandleValueChanged;
            product.Click += HandleAnswerEnter;
            product.Enter += HandleAnswerEnter;
            // 
            // timesRightLabel
            // 
            timesRightLabel.Font = new Font("Microsoft YaHei UI", 18F);
            timesRightLabel.Location = new Point(182, 175);
            timesRightLabel.Name = "timesRightLabel";
            timesRightLabel.Size = new Size(60, 50);
            timesRightLabel.TabIndex = 15;
            timesRightLabel.Text = "?";
            timesRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft YaHei UI", 18F);
            label6.Location = new Point(248, 175);
            label6.Name = "label6";
            label6.Size = new Size(60, 50);
            label6.TabIndex = 14;
            label6.Text = "=";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timesOperatorLabel
            // 
            timesOperatorLabel.Font = new Font("Microsoft YaHei UI", 18F);
            timesOperatorLabel.Location = new Point(116, 175);
            timesOperatorLabel.Name = "timesOperatorLabel";
            timesOperatorLabel.Size = new Size(60, 50);
            timesOperatorLabel.TabIndex = 13;
            timesOperatorLabel.Text = "*";
            timesOperatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timesLeftLabel
            // 
            timesLeftLabel.Font = new Font("Microsoft YaHei UI", 18F);
            timesLeftLabel.Location = new Point(50, 175);
            timesLeftLabel.Name = "timesLeftLabel";
            timesLeftLabel.Size = new Size(60, 50);
            timesLeftLabel.TabIndex = 12;
            timesLeftLabel.Text = "?";
            timesLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // quotient
            // 
            quotient.Font = new Font("Microsoft YaHei UI", 18F);
            quotient.Location = new Point(314, 233);
            quotient.Name = "quotient";
            quotient.Size = new Size(100, 38);
            quotient.TabIndex = 4;
            quotient.ValueChanged += HandleValueChanged;
            quotient.Click += HandleAnswerEnter;
            quotient.Enter += HandleAnswerEnter;
            // 
            // dividedRightLabel
            // 
            dividedRightLabel.Font = new Font("Microsoft YaHei UI", 18F);
            dividedRightLabel.Location = new Point(182, 225);
            dividedRightLabel.Name = "dividedRightLabel";
            dividedRightLabel.Size = new Size(60, 50);
            dividedRightLabel.TabIndex = 20;
            dividedRightLabel.Text = "?";
            dividedRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft YaHei UI", 18F);
            label7.Location = new Point(248, 225);
            label7.Name = "label7";
            label7.Size = new Size(60, 50);
            label7.TabIndex = 19;
            label7.Text = "=";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dividedOperatorLabel
            // 
            dividedOperatorLabel.Font = new Font("Microsoft YaHei UI", 18F);
            dividedOperatorLabel.Location = new Point(116, 225);
            dividedOperatorLabel.Name = "dividedOperatorLabel";
            dividedOperatorLabel.Size = new Size(60, 50);
            dividedOperatorLabel.TabIndex = 18;
            dividedOperatorLabel.Text = "/";
            dividedOperatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dividedLeftLabel
            // 
            dividedLeftLabel.Font = new Font("Microsoft YaHei UI", 18F);
            dividedLeftLabel.Location = new Point(50, 225);
            dividedLeftLabel.Name = "dividedLeftLabel";
            dividedLeftLabel.Size = new Size(60, 50);
            dividedLeftLabel.TabIndex = 17;
            dividedLeftLabel.Text = "?";
            dividedLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startBtn
            // 
            startBtn.AutoSize = true;
            startBtn.Font = new Font("Microsoft YaHei UI", 14F);
            startBtn.Location = new Point(182, 294);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(112, 35);
            startBtn.TabIndex = 0;
            startBtn.Text = "Start Quiz";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += HandleStartQuiz;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += HandlerTimerTick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 357);
            Controls.Add(startBtn);
            Controls.Add(quotient);
            Controls.Add(dividedRightLabel);
            Controls.Add(label7);
            Controls.Add(dividedOperatorLabel);
            Controls.Add(dividedLeftLabel);
            Controls.Add(product);
            Controls.Add(timesRightLabel);
            Controls.Add(label6);
            Controls.Add(timesOperatorLabel);
            Controls.Add(timesLeftLabel);
            Controls.Add(difference);
            Controls.Add(minusRightLabel);
            Controls.Add(label5);
            Controls.Add(minusOperatorLabel);
            Controls.Add(minusLeftLabel);
            Controls.Add(sum);
            Controls.Add(plusRightLabel);
            Controls.Add(label4);
            Controls.Add(plusOepratorLabel);
            Controls.Add(plusLeftLabel);
            Controls.Add(label2);
            Controls.Add(timeLeftLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Math Quiz";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)sum).EndInit();
            ((System.ComponentModel.ISupportInitialize)difference).EndInit();
            ((System.ComponentModel.ISupportInitialize)product).EndInit();
            ((System.ComponentModel.ISupportInitialize)quotient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timeLeftLabel;
        private Label label2;
        private Label plusLeftLabel;
        private Label plusOepratorLabel;
        private Label label4;
        private Label plusRightLabel;
        private NumericUpDown sum;
        private NumericUpDown difference;
        private Label minusRightLabel;
        private Label label5;
        private Label minusOperatorLabel;
        private Label minusLeftLabel;
        private NumericUpDown product;
        private Label timesRightLabel;
        private Label label6;
        private Label timesOperatorLabel;
        private Label timesLeftLabel;
        private NumericUpDown quotient;
        private Label dividedRightLabel;
        private Label label7;
        private Label dividedOperatorLabel;
        private Label dividedLeftLabel;
        private Button startBtn;
        private System.Windows.Forms.Timer timer1;
    }
}
