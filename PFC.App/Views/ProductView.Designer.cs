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
            listBox1 = new ListBox();
            panel5 = new Panel();
            panel4 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel3 = new Panel();
            btnAddProduct = new PFC.App.Controls.SfRoundedButton();
            btnSoda = new PFC.App.Controls.SfRoundedButton();
            btnMatcha = new PFC.App.Controls.SfRoundedButton();
            btnFlavMilk = new PFC.App.Controls.SfRoundedButton();
            btnHotCoffee = new PFC.App.Controls.SfRoundedButton();
            btnIcedCoffee = new PFC.App.Controls.SfRoundedButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
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
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 67);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(275, 641);
            listBox1.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 708);
            panel5.Margin = new Padding(3, 0, 3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(275, 226);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(275, 67);
            panel4.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Orange;
            label3.Location = new Point(192, 25);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 1;
            label3.Text = "0 Items";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(130, 25);
            label2.TabIndex = 0;
            label2.Text = "Current Order";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnAddProduct);
            panel3.Controls.Add(btnSoda);
            panel3.Controls.Add(btnMatcha);
            panel3.Controls.Add(btnFlavMilk);
            panel3.Controls.Add(btnHotCoffee);
            panel3.Controls.Add(btnIcedCoffee);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(275, 66);
            panel3.Name = "panel3";
            panel3.Size = new Size(830, 102);
            panel3.TabIndex = 3;
            // 
            // btnAddProduct
            // 
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI Semibold", 9F);
            btnAddProduct.Location = new Point(566, 41);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(148, 35);
            btnAddProduct.Style.FocusedBackColor = Color.LemonChiffon;
            btnAddProduct.Style.FocusedBorder = null;
            btnAddProduct.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnAddProduct.Style.HoverForeColor = Color.Black;
            btnAddProduct.TabIndex = 7;
            btnAddProduct.Text = "Add New Product";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnSoda
            // 
            btnSoda.FlatStyle = FlatStyle.Flat;
            btnSoda.Font = new Font("Segoe UI Semibold", 9F);
            btnSoda.Location = new Point(395, 41);
            btnSoda.Name = "btnSoda";
            btnSoda.Size = new Size(54, 35);
            btnSoda.Style.FocusedBackColor = Color.LemonChiffon;
            btnSoda.Style.FocusedBorder = null;
            btnSoda.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnSoda.Style.HoverForeColor = Color.Black;
            btnSoda.TabIndex = 6;
            btnSoda.Text = "Soda";
            // 
            // btnMatcha
            // 
            btnMatcha.FlatStyle = FlatStyle.Flat;
            btnMatcha.Font = new Font("Segoe UI Semibold", 9F);
            btnMatcha.Location = new Point(318, 41);
            btnMatcha.Name = "btnMatcha";
            btnMatcha.Size = new Size(71, 35);
            btnMatcha.Style.FocusedBackColor = Color.LemonChiffon;
            btnMatcha.Style.FocusedBorder = null;
            btnMatcha.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnMatcha.Style.HoverForeColor = Color.Black;
            btnMatcha.TabIndex = 5;
            btnMatcha.Text = "Matcha";
            // 
            // btnFlavMilk
            // 
            btnFlavMilk.FlatStyle = FlatStyle.Flat;
            btnFlavMilk.Font = new Font("Segoe UI Semibold", 9F);
            btnFlavMilk.Location = new Point(204, 41);
            btnFlavMilk.Name = "btnFlavMilk";
            btnFlavMilk.Size = new Size(108, 35);
            btnFlavMilk.Style.FocusedBackColor = Color.LemonChiffon;
            btnFlavMilk.Style.FocusedBorder = null;
            btnFlavMilk.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnFlavMilk.Style.HoverForeColor = Color.Black;
            btnFlavMilk.TabIndex = 4;
            btnFlavMilk.Text = "Flavored Milk";
            // 
            // btnHotCoffee
            // 
            btnHotCoffee.FlatStyle = FlatStyle.Flat;
            btnHotCoffee.Font = new Font("Segoe UI Semibold", 9F);
            btnHotCoffee.Location = new Point(105, 41);
            btnHotCoffee.Name = "btnHotCoffee";
            btnHotCoffee.Size = new Size(93, 35);
            btnHotCoffee.Style.FocusedBackColor = Color.LemonChiffon;
            btnHotCoffee.Style.FocusedBorder = null;
            btnHotCoffee.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnHotCoffee.Style.HoverForeColor = Color.Black;
            btnHotCoffee.TabIndex = 3;
            btnHotCoffee.Text = "Hot Coffee";
            // 
            // btnIcedCoffee
            // 
            btnIcedCoffee.FlatStyle = FlatStyle.Flat;
            btnIcedCoffee.Font = new Font("Segoe UI Semibold", 9F);
            btnIcedCoffee.Location = new Point(6, 41);
            btnIcedCoffee.Name = "btnIcedCoffee";
            btnIcedCoffee.Size = new Size(93, 35);
            btnIcedCoffee.Style.FocusedBackColor = Color.LemonChiffon;
            btnIcedCoffee.Style.FocusedBorder = null;
            btnIcedCoffee.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnIcedCoffee.Style.HoverForeColor = Color.Black;
            btnIcedCoffee.TabIndex = 2;
            btnIcedCoffee.Text = "Iced Coffee";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(275, 168);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(830, 832);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductView";
            Size = new Size(1105, 1000);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
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
        private Label label3;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.SfRoundedButton btnIcedCoffee;
        private Controls.SfRoundedButton btnSoda;
        private Controls.SfRoundedButton btnMatcha;
        private Controls.SfRoundedButton btnFlavMilk;
        private Controls.SfRoundedButton btnHotCoffee;
        private Controls.SfRoundedButton btnAddProduct;
    }
}
