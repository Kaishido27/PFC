namespace PFC.App.Forms
{
    partial class OrderEntryForm
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
            pfcRoundedGradientPanel1 = new PFC.App.Controls.PfcRoundedGradientPanel();
            pictureBox1 = new PictureBox();
            lblProductCategory = new Label();
            lblProductName = new Label();
            label1 = new Label();
            label2 = new Label();
            chkAddOns = new CheckedListBox();
            label3 = new Label();
            numQuantity = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            label4 = new Label();
            lblLiveTotal = new Label();
            btnConfirm = new PFC.App.Controls.SfRoundedButton();
            btnCancel = new PFC.App.Controls.SfRoundedButton();
            cboSizes = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pfcRoundedGradientPanel1).BeginInit();
            pfcRoundedGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // pfcRoundedGradientPanel1
            // 
            pfcRoundedGradientPanel1.BackColor = Color.FromArgb(0, 131, 143);
            pfcRoundedGradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, SystemColors.ControlLightLight, Color.DodgerBlue);
            pfcRoundedGradientPanel1.Border3DStyle = Border3DStyle.Bump;
            pfcRoundedGradientPanel1.BorderColor = Color.White;
            pfcRoundedGradientPanel1.BorderStyle = BorderStyle.None;
            pfcRoundedGradientPanel1.Controls.Add(pictureBox1);
            pfcRoundedGradientPanel1.Controls.Add(lblProductCategory);
            pfcRoundedGradientPanel1.Controls.Add(lblProductName);
            pfcRoundedGradientPanel1.Location = new Point(12, 12);
            pfcRoundedGradientPanel1.Name = "pfcRoundedGradientPanel1";
            pfcRoundedGradientPanel1.Size = new Size(608, 93);
            pfcRoundedGradientPanel1.TabIndex = 0;
            pfcRoundedGradientPanel1.ThemeStyle.BackColor = Color.PeachPuff;
            pfcRoundedGradientPanel1.ThemeStyle.BorderColor = Color.Black;
            pfcRoundedGradientPanel1.ThemeStyle.BorderThickness = 20;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo_goldIcon;
            pictureBox1.Location = new Point(25, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblProductCategory
            // 
            lblProductCategory.AutoSize = true;
            lblProductCategory.BackColor = Color.Transparent;
            lblProductCategory.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblProductCategory.Location = new Point(130, 47);
            lblProductCategory.Name = "lblProductCategory";
            lblProductCategory.Size = new Size(93, 28);
            lblProductCategory.TabIndex = 2;
            lblProductCategory.Text = "Category";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.BackColor = Color.Transparent;
            lblProductName.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(128, 9);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(95, 38);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(37, 146);
            label1.Name = "label1";
            label1.Size = new Size(148, 31);
            label1.TabIndex = 3;
            label1.Text = "SELECT SIZE:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 241);
            label2.Name = "label2";
            label2.Size = new Size(240, 31);
            label2.TabIndex = 5;
            label2.Text = "ADD-ONS (+10 each)";
            // 
            // chkAddOns
            // 
            chkAddOns.BorderStyle = BorderStyle.None;
            chkAddOns.CheckOnClick = true;
            chkAddOns.FormattingEnabled = true;
            chkAddOns.Location = new Point(25, 291);
            chkAddOns.Name = "chkAddOns";
            chkAddOns.Size = new Size(577, 154);
            chkAddOns.TabIndex = 6;
            chkAddOns.ItemCheck += chkAddOns_ItemCheck;
            chkAddOns.Format += ChkAddOns_Format;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 473);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 7;
            label3.Text = "QUANTITY:";
            // 
            // numQuantity
            // 
            numQuantity.BeforeTouchSize = new Size(253, 34);
            numQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numQuantity.Location = new Point(25, 516);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(253, 34);
            numQuantity.TabIndex = 8;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 573);
            label4.Name = "label4";
            label4.Size = new Size(139, 31);
            label4.TabIndex = 9;
            label4.Text = "LIVE TOTAL:";
            // 
            // lblLiveTotal
            // 
            lblLiveTotal.AutoSize = true;
            lblLiveTotal.BackColor = Color.Transparent;
            lblLiveTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLiveTotal.ForeColor = Color.DarkGreen;
            lblLiveTotal.Location = new Point(408, 573);
            lblLiveTotal.Name = "lblLiveTotal";
            lblLiveTotal.Size = new Size(133, 31);
            lblLiveTotal.TabIndex = 10;
            lblLiveTotal.Text = "LIVE TOTAL";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.ForestGreen;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(60, 653);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(236, 45);
            btnConfirm.Style.BackColor = Color.ForestGreen;
            btnConfirm.Style.FocusedBorder = null;
            btnConfirm.Style.ForeColor = Color.White;
            btnConfirm.Style.HoverBackColor = Color.LimeGreen;
            btnConfirm.Style.PressedBackColor = Color.LimeGreen;
            btnConfirm.TabIndex = 11;
            btnConfirm.Text = "+ Confirm Order";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(335, 653);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(236, 45);
            btnCancel.Style.FocusedBorder = null;
            btnCancel.Style.HoverBackColor = Color.Red;
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            // 
            // cboSizes
            // 
            cboSizes.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboSizes.FormattingEnabled = true;
            cboSizes.Location = new Point(325, 146);
            cboSizes.Name = "cboSizes";
            cboSizes.Size = new Size(246, 28);
            cboSizes.TabIndex = 13;
            cboSizes.SelectedIndexChanged += cboSizes_SelectedIndexChanged;
            cboSizes.Format += cboSizes_Format;
            // 
            // OrderEntryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(632, 730);
            Controls.Add(cboSizes);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(lblLiveTotal);
            Controls.Add(label4);
            Controls.Add(numQuantity);
            Controls.Add(label3);
            Controls.Add(chkAddOns);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pfcRoundedGradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrderEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "OrderEntryForm";
            ((System.ComponentModel.ISupportInitialize)pfcRoundedGradientPanel1).EndInit();
            pfcRoundedGradientPanel1.ResumeLayout(false);
            pfcRoundedGradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Controls.PfcRoundedGradientPanel pfcRoundedGradientPanel1;
        private Label lblProductCategory;
        private Label lblProductName;
        private Label label1;
        private Label label2;
        private CheckedListBox chkAddOns;
        private Label label3;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt numQuantity;
        private Label label4;
        private Label lblLiveTotal;
        private Controls.SfRoundedButton btnConfirm;
        private Controls.SfRoundedButton btnCancel;
        private PictureBox pictureBox1;
        private ComboBox cboSizes;
    }
}