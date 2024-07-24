namespace WinFormsApp.HelloWorld
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
            button1 = new Button();
            lb1HelloWorld = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(382, 154);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Click Me:)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonClickCallback;
            // 
            // lb1HelloWorld
            // 
            lb1HelloWorld.AutoSize = true;
            lb1HelloWorld.Location = new Point(382, 192);
            lb1HelloWorld.Name = "lb1HelloWorld";
            lb1HelloWorld.Size = new Size(43, 17);
            lb1HelloWorld.TabIndex = 1;
            lb1HelloWorld.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lb1HelloWorld);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label lb1HelloWorld;
    }
}
