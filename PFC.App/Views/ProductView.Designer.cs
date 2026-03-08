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
            flwCartItems = new FlowLayoutPanel();
            btnConfirmOrder = new Panel();
            btnOnline = new PFC.App.Controls.SfRoundedButton();
            btnCash = new PFC.App.Controls.SfRoundedButton();
            btnConfirm = new PFC.App.Controls.SfRoundedButton();
            lblGrandTotal = new Label();
            label4 = new Label();
            panel4 = new Panel();
            lblItemCount = new Label();
            label2 = new Label();
            panel3 = new Panel();
            txtSearch = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnAddProduct = new PFC.App.Controls.SfRoundedButton();
            btnSoda = new PFC.App.Controls.SfRoundedButton();
            btnMatcha = new PFC.App.Controls.SfRoundedButton();
            btnFlavMilk = new PFC.App.Controls.SfRoundedButton();
            btnHotCoffee = new PFC.App.Controls.SfRoundedButton();
            btnIcedCoffee = new PFC.App.Controls.SfRoundedButton();
            panel5 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            chkShowArchived = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            btnConfirmOrder.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSearch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkShowArchived).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 16);
            label1.Name = "label1";
            label1.Size = new Size(109, 31);
            label1.TabIndex = 0;
            label1.Text = "Products";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Beige;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1333, 66);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(flwCartItems);
            panel2.Controls.Add(btnConfirmOrder);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(275, 960);
            panel2.TabIndex = 2;
            // 
            // flwCartItems
            // 
            flwCartItems.AutoScroll = true;
            flwCartItems.Dock = DockStyle.Fill;
            flwCartItems.Location = new Point(0, 67);
            flwCartItems.Name = "flwCartItems";
            flwCartItems.Size = new Size(273, 673);
            flwCartItems.TabIndex = 2;
            // 
            // btnConfirmOrder
            // 
            btnConfirmOrder.BorderStyle = BorderStyle.FixedSingle;
            btnConfirmOrder.Controls.Add(btnOnline);
            btnConfirmOrder.Controls.Add(btnCash);
            btnConfirmOrder.Controls.Add(btnConfirm);
            btnConfirmOrder.Controls.Add(lblGrandTotal);
            btnConfirmOrder.Controls.Add(label4);
            btnConfirmOrder.Dock = DockStyle.Bottom;
            btnConfirmOrder.Location = new Point(0, 740);
            btnConfirmOrder.Margin = new Padding(3, 0, 3, 3);
            btnConfirmOrder.Name = "btnConfirmOrder";
            btnConfirmOrder.Size = new Size(273, 218);
            btnConfirmOrder.TabIndex = 1;
            // 
            // btnOnline
            // 
            btnOnline.BackColor = Color.Silver;
            btnOnline.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOnline.Location = new Point(141, 88);
            btnOnline.Name = "btnOnline";
            btnOnline.Size = new Size(107, 35);
            btnOnline.Style.BackColor = Color.Silver;
            btnOnline.Style.FocusedBorder = null;
            btnOnline.Style.HoverBackColor = Color.FromArgb(128, 255, 128);
            btnOnline.TabIndex = 14;
            btnOnline.Text = "ONLINE";
            btnOnline.UseVisualStyleBackColor = false;
            btnOnline.Click += btnOnline_Click;
            // 
            // btnCash
            // 
            btnCash.BackColor = Color.Silver;
            btnCash.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCash.Location = new Point(12, 88);
            btnCash.Name = "btnCash";
            btnCash.Size = new Size(107, 35);
            btnCash.Style.BackColor = Color.Silver;
            btnCash.Style.FocusedBorder = null;
            btnCash.Style.HoverBackColor = Color.FromArgb(128, 255, 128);
            btnCash.TabIndex = 13;
            btnCash.Text = "CASH";
            btnCash.UseVisualStyleBackColor = false;
            btnCash.Click += btnCash_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.ForestGreen;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(12, 143);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(236, 45);
            btnConfirm.Style.BackColor = Color.ForestGreen;
            btnConfirm.Style.FocusedBackColor = Color.ForestGreen;
            btnConfirm.Style.FocusedBorder = null;
            btnConfirm.Style.FocusedForeColor = Color.White;
            btnConfirm.Style.ForeColor = Color.White;
            btnConfirm.Style.HoverBackColor = Color.LimeGreen;
            btnConfirm.Style.PressedBackColor = Color.LimeGreen;
            btnConfirm.TabIndex = 12;
            btnConfirm.Text = "+ Confirm Order";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirmOrder_Click;
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandTotal.ForeColor = Color.DarkGreen;
            lblGrandTotal.Location = new Point(140, 20);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(101, 23);
            lblGrandTotal.TabIndex = 3;
            lblGrandTotal.Text = "Total Order";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 20);
            label4.Name = "label4";
            label4.Size = new Size(107, 23);
            label4.TabIndex = 2;
            label4.Text = "Total Order:";
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblItemCount);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(273, 67);
            panel4.TabIndex = 0;
            // 
            // lblItemCount
            // 
            lblItemCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblItemCount.AutoSize = true;
            lblItemCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblItemCount.ForeColor = Color.Orange;
            lblItemCount.Location = new Point(190, 25);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(62, 20);
            lblItemCount.TabIndex = 1;
            lblItemCount.Text = "0 Items";
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
            panel3.Controls.Add(chkShowArchived);
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(btnAddProduct);
            panel3.Controls.Add(btnSoda);
            panel3.Controls.Add(btnMatcha);
            panel3.Controls.Add(btnFlavMilk);
            panel3.Controls.Add(btnHotCoffee);
            panel3.Controls.Add(btnIcedCoffee);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(275, 66);
            panel3.Name = "panel3";
            panel3.Size = new Size(1058, 102);
            panel3.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSearch.BackColor = SystemColors.Info;
            txtSearch.BeforeTouchSize = new Size(249, 27);
            txtSearch.Border3DStyle = Border3DStyle.Flat;
            txtSearch.Location = new Point(588, 43);
            txtSearch.Name = "txtSearch";
            txtSearch.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Silver;
            txtSearch.PlaceholderText = "Search Products";
            txtSearch.Size = new Size(249, 27);
            txtSearch.TabIndex = 8;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddProduct.BackColor = Color.Tan;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Segoe UI Semibold", 9F);
            btnAddProduct.Location = new Point(859, 27);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(148, 51);
            btnAddProduct.Style.BackColor = Color.Tan;
            btnAddProduct.Style.FocusedBackColor = Color.LemonChiffon;
            btnAddProduct.Style.FocusedBorder = null;
            btnAddProduct.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnAddProduct.Style.HoverForeColor = Color.Black;
            btnAddProduct.TabIndex = 7;
            btnAddProduct.Text = "Add New Product";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnSoda
            // 
            btnSoda.FlatStyle = FlatStyle.Flat;
            btnSoda.Font = new Font("Segoe UI Semibold", 9F);
            btnSoda.Location = new Point(418, 43);
            btnSoda.Name = "btnSoda";
            btnSoda.Size = new Size(54, 35);
            btnSoda.Style.FocusedBackColor = Color.LemonChiffon;
            btnSoda.Style.FocusedBorder = null;
            btnSoda.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnSoda.Style.HoverForeColor = Color.Black;
            btnSoda.TabIndex = 6;
            btnSoda.Text = "Soda";
            btnSoda.Click += BtnSoda_Click;
            // 
            // btnMatcha
            // 
            btnMatcha.FlatStyle = FlatStyle.Flat;
            btnMatcha.Font = new Font("Segoe UI Semibold", 9F);
            btnMatcha.Location = new Point(341, 43);
            btnMatcha.Name = "btnMatcha";
            btnMatcha.Size = new Size(71, 35);
            btnMatcha.Style.FocusedBackColor = Color.LemonChiffon;
            btnMatcha.Style.FocusedBorder = null;
            btnMatcha.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnMatcha.Style.HoverForeColor = Color.Black;
            btnMatcha.TabIndex = 5;
            btnMatcha.Text = "Matcha";
            btnMatcha.Click += BtnMatcha_Click;
            // 
            // btnFlavMilk
            // 
            btnFlavMilk.FlatStyle = FlatStyle.Flat;
            btnFlavMilk.Font = new Font("Segoe UI Semibold", 9F);
            btnFlavMilk.Location = new Point(227, 43);
            btnFlavMilk.Name = "btnFlavMilk";
            btnFlavMilk.Size = new Size(108, 35);
            btnFlavMilk.Style.FocusedBackColor = Color.LemonChiffon;
            btnFlavMilk.Style.FocusedBorder = null;
            btnFlavMilk.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnFlavMilk.Style.HoverForeColor = Color.Black;
            btnFlavMilk.TabIndex = 4;
            btnFlavMilk.Text = "Flavored Milk";
            btnFlavMilk.Click += BtnFlavMilk_Click;
            // 
            // btnHotCoffee
            // 
            btnHotCoffee.FlatStyle = FlatStyle.Flat;
            btnHotCoffee.Font = new Font("Segoe UI Semibold", 9F);
            btnHotCoffee.Location = new Point(128, 43);
            btnHotCoffee.Name = "btnHotCoffee";
            btnHotCoffee.Size = new Size(93, 35);
            btnHotCoffee.Style.FocusedBackColor = Color.LemonChiffon;
            btnHotCoffee.Style.FocusedBorder = null;
            btnHotCoffee.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnHotCoffee.Style.HoverForeColor = Color.Black;
            btnHotCoffee.TabIndex = 3;
            btnHotCoffee.Text = "Hot Coffee";
            btnHotCoffee.Click += BtnHotCoffee_Click;
            // 
            // btnIcedCoffee
            // 
            btnIcedCoffee.FlatStyle = FlatStyle.Flat;
            btnIcedCoffee.Font = new Font("Segoe UI Semibold", 9F);
            btnIcedCoffee.Location = new Point(29, 43);
            btnIcedCoffee.Name = "btnIcedCoffee";
            btnIcedCoffee.Size = new Size(93, 35);
            btnIcedCoffee.Style.FocusedBackColor = Color.LemonChiffon;
            btnIcedCoffee.Style.FocusedBorder = null;
            btnIcedCoffee.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            btnIcedCoffee.Style.HoverForeColor = Color.Black;
            btnIcedCoffee.TabIndex = 2;
            btnIcedCoffee.Text = "Iced Coffee";
            btnIcedCoffee.Click += BtnIcedCoffee_Click;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(946, 168);
            panel5.Name = "panel5";
            panel5.Size = new Size(387, 858);
            panel5.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(275, 168);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(671, 858);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // chkShowArchived
            // 
            chkShowArchived.AccessibilityEnabled = true;
            chkShowArchived.BeforeTouchSize = new Size(188, 26);
            chkShowArchived.ImageCheckBoxSize = new Size(16, 16);
            chkShowArchived.Location = new Point(588, 73);
            chkShowArchived.Name = "chkShowArchived";
            chkShowArchived.Size = new Size(188, 26);
            chkShowArchived.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2010;
            chkShowArchived.TabIndex = 9;
            chkShowArchived.Text = "Show Archived Products";
            chkShowArchived.ThemeName = "Office2010";
            chkShowArchived.CheckStateChanged += chkShowArchived_CheckStateChanged;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductView";
            Size = new Size(1333, 1026);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            btnConfirmOrder.ResumeLayout(false);
            btnConfirmOrder.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtSearch).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkShowArchived).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel btnConfirmOrder;
        private Label lblItemCount;
        private Label label2;
        private Controls.SfRoundedButton btnIcedCoffee;
        private Controls.SfRoundedButton btnSoda;
        private Controls.SfRoundedButton btnMatcha;
        private Controls.SfRoundedButton btnFlavMilk;
        private Controls.SfRoundedButton btnHotCoffee;
        private Controls.SfRoundedButton btnAddProduct;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSearch;
        private FlowLayoutPanel flwCartItems;
        private Label label4;
        private Label lblGrandTotal;
        private Controls.SfRoundedButton btnConfirm;
        private Panel panel5;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.SfRoundedButton btnCash;
        private Controls.SfRoundedButton btnOnline;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv chkShowArchived;
    }
}
