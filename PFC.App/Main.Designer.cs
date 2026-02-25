namespace PFC.App
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            designTimeTabTypeLoader = new Syncfusion.Reflection.TypeLoader(components);
            ((System.ComponentModel.ISupportInitialize)tabControlAdv1).BeginInit();
            tabControlAdv1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlAdv1
            // 
            tabControlAdv1.ActiveTabFont = new Font("Segoe UI", 9F);
            tabControlAdv1.Alignment = TabAlignment.Left;
            tabControlAdv1.BackColor = Color.DeepSkyBlue;
            tabControlAdv1.BeforeTouchSize = new Size(1288, 948);
            tabControlAdv1.CanOverrideStyle = true;
            tabControlAdv1.Controls.Add(tabPageAdv1);
            tabControlAdv1.Controls.Add(tabPageAdv2);
            tabControlAdv1.FocusOnTabClick = false;
            tabControlAdv1.ItemSize = new Size(200, 105);
            tabControlAdv1.Location = new Point(0, 85);
            tabControlAdv1.Name = "tabControlAdv1";
            tabControlAdv1.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Silver;
            tabControlAdv1.Padding = new Point(2, 3);
            tabControlAdv1.RotateTextWhenVertical = true;
            tabControlAdv1.Size = new Size(1288, 948);
            tabControlAdv1.TabGap = 14;
            tabControlAdv1.TabIndex = 3;
            tabControlAdv1.TabPanelBackColor = SystemColors.Control;
            tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererIE7);
            tabControlAdv1.ThemeName = "TabRendererIE7";
            tabControlAdv1.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // tabPageAdv1
            // 
            tabPageAdv1.BackColor = Color.PapayaWhip;
            tabPageAdv1.Image = null;
            tabPageAdv1.ImageSize = new Size(20, 20);
            tabPageAdv1.Location = new Point(209, 1);
            tabPageAdv1.Name = "tabPageAdv1";
            tabPageAdv1.ShowCloseButton = true;
            tabPageAdv1.Size = new Size(1077, 945);
            tabPageAdv1.TabIndex = 1;
            tabPageAdv1.Text = "tabPageAdv1";
            tabPageAdv1.ThemesEnabled = false;
            // 
            // tabPageAdv2
            // 
            tabPageAdv2.Image = null;
            tabPageAdv2.ImageSize = new Size(20, 20);
            tabPageAdv2.Location = new Point(209, 1);
            tabPageAdv2.Name = "tabPageAdv2";
            tabPageAdv2.ShowCloseButton = true;
            tabPageAdv2.Size = new Size(1077, 945);
            tabPageAdv2.TabIndex = 2;
            tabPageAdv2.Text = "tabPageAdv2";
            tabPageAdv2.ThemesEnabled = false;
            // 
            // designTimeTabTypeLoader
            // 
            designTimeTabTypeLoader.InvokeMemberName = "TabStyleName";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1902, 1033);
            Controls.Add(tabControlAdv1);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)tabControlAdv1).EndInit();
            tabControlAdv1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private Syncfusion.Reflection.TypeLoader designTimeTabTypeLoader;
    }
}