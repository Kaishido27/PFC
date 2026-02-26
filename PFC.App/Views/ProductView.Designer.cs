namespace PFC.App.Views
{
    partial class ProductView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            listBox1 = new ListBox();
            sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 16);
            label1.Name = "label1";
            label1.Size = new Size(236, 31);
            label1.TabIndex = 0;
            label1.Text = "Dashboard Overview";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Beige;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 66);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(listBox1);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(275, 934);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(275, 66);
            panel3.Name = "panel3";
            panel3.Size = new Size(830, 70);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(275, 67);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 683);
            panel5.Name = "panel5";
            panel5.Size = new Size(275, 251);
            panel5.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 67);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(275, 616);
            listBox1.TabIndex = 2;
            // 
            // sfButton1
            // 
            sfButton1.Font = new Font("Segoe UI Semibold", 9F);
            sfButton1.Location = new Point(463, 893);
            sfButton1.Name = "sfButton1";
            sfButton1.Size = new Size(120, 35);
            sfButton1.TabIndex = 4;
            sfButton1.Text = "sfButton1";
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(sfButton1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductView";
            Size = new Size(1105, 1000);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private ListBox listBox1;
        private Panel panel5;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
    }
}
