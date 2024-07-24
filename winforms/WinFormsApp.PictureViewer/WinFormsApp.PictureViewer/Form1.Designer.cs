namespace WinFormsApp.PictureViewer
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            closeBtn = new Button();
            bgColorBtn = new Button();
            clearBtn = new Button();
            showBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(752, 524);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(746, 465);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Dock = DockStyle.Top;
            checkBox1.Location = new Point(3, 474);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 21);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Stretch";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += HandlePictureStretch;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(closeBtn);
            flowLayoutPanel1.Controls.Add(bgColorBtn);
            flowLayoutPanel1.Controls.Add(clearBtn);
            flowLayoutPanel1.Controls.Add(showBtn);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(115, 474);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(634, 47);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // closeBtn
            // 
            closeBtn.AutoSize = true;
            closeBtn.Location = new Point(3, 3);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(75, 27);
            closeBtn.TabIndex = 0;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += HandleClose;
            // 
            // bgColorBtn
            // 
            bgColorBtn.AutoSize = true;
            bgColorBtn.Location = new Point(84, 3);
            bgColorBtn.Name = "bgColorBtn";
            bgColorBtn.Size = new Size(216, 27);
            bgColorBtn.TabIndex = 1;
            bgColorBtn.Text = "Set the background color";
            bgColorBtn.UseVisualStyleBackColor = true;
            bgColorBtn.Click += HandleSetPictureBgColor;
            // 
            // clearBtn
            // 
            clearBtn.AutoSize = true;
            clearBtn.Location = new Point(306, 3);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(134, 27);
            clearBtn.TabIndex = 2;
            clearBtn.Text = "Clear the picture";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += HandleClearPicture;
            // 
            // showBtn
            // 
            showBtn.AutoSize = true;
            showBtn.Location = new Point(446, 3);
            showBtn.Name = "showBtn";
            showBtn.Size = new Size(125, 27);
            showBtn.TabIndex = 3;
            showBtn.Text = "Show a picture";
            showBtn.UseVisualStyleBackColor = true;
            showBtn.Click += HandleShowPicture;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.Title = "Choose a picture file:)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 524);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "PictureViewer";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button closeBtn;
        private Button bgColorBtn;
        private Button clearBtn;
        private Button showBtn;
        private OpenFileDialog openFileDialog1;
        private ColorDialog colorDialog1;
    }
}
