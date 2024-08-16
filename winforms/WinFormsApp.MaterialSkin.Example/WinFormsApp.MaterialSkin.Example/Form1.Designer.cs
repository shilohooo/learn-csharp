using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin.Properties;

namespace WinFormsApp.MaterialSkin.Example
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
            materialTabControl1 = new MaterialTabControl();
            userTab = new TabPage();
            roleTab = new TabPage();
            addRoleBtn = new MaterialButton();
            addUserBtn = new MaterialButton();
            materialTabControl1.SuspendLayout();
            userTab.SuspendLayout();
            roleTab.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(userTab);
            materialTabControl1.Controls.Add(roleTab);
            materialTabControl1.Depth = 0;
            materialTabControl1.Location = new Point(245, 125);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(403, 233);
            materialTabControl1.TabIndex = 0;
            // 
            // userTab
            // 
            userTab.Controls.Add(addUserBtn);
            userTab.Location = new Point(4, 26);
            userTab.Name = "userTab";
            userTab.Padding = new Padding(3);
            userTab.Size = new Size(395, 203);
            userTab.TabIndex = 1;
            userTab.Text = "用户管理";
            userTab.UseVisualStyleBackColor = true;
            // 
            // roleTab
            // 
            roleTab.Controls.Add(addRoleBtn);
            roleTab.Location = new Point(4, 26);
            roleTab.Name = "roleTab";
            roleTab.Padding = new Padding(3);
            roleTab.Size = new Size(395, 203);
            roleTab.TabIndex = 2;
            roleTab.Text = "角色管理";
            roleTab.UseVisualStyleBackColor = true;
            // 
            // addRoleBtn
            // 
            addRoleBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addRoleBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addRoleBtn.Depth = 0;
            addRoleBtn.HighEmphasis = true;
            addRoleBtn.Icon = null;
            addRoleBtn.Location = new Point(99, 85);
            addRoleBtn.Margin = new Padding(4, 6, 4, 6);
            addRoleBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addRoleBtn.Name = "addRoleBtn";
            addRoleBtn.NoAccentTextColor = Color.Empty;
            addRoleBtn.Size = new Size(85, 36);
            addRoleBtn.TabIndex = 0;
            addRoleBtn.Text = "新增角色";
            addRoleBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addRoleBtn.UseAccentColor = false;
            addRoleBtn.UseVisualStyleBackColor = true;
            // 
            // addUserBtn
            // 
            addUserBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addUserBtn.Depth = 0;
            addUserBtn.HighEmphasis = true;
            addUserBtn.Icon = null;
            addUserBtn.Location = new Point(167, 77);
            addUserBtn.Margin = new Padding(4, 6, 4, 6);
            addUserBtn.MouseState = MaterialSkin.MouseState.HOVER;
            addUserBtn.Name = "addUserBtn";
            addUserBtn.NoAccentTextColor = Color.Empty;
            addUserBtn.Size = new Size(158, 36);
            addUserBtn.TabIndex = 0;
            addUserBtn.Text = "新增用户";
            addUserBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addUserBtn.UseAccentColor = false;
            addUserBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(materialTabControl1);
            Name = "Form1";
            Text = "Form1";
            materialTabControl1.ResumeLayout(false);
            userTab.ResumeLayout(false);
            userTab.PerformLayout();
            roleTab.ResumeLayout(false);
            roleTab.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabPage roleTab;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private MaterialTabControl materialTabControl1;
        private TabPage userTab;
        private MaterialButton addRoleBtn;
        private MaterialButton addUserBtn;
    }
}
