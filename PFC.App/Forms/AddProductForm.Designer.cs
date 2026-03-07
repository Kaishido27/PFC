namespace PFC.App.Forms
{
    partial class AddProductForm
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
            gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            sfRoundedButtonAddSize = new PFC.App.Controls.SfRoundedButton();
            dataGridView1 = new DataGridView();
            Sizeoption = new DataGridViewComboBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            Actions = new DataGridViewButtonColumn();
            label5 = new Label();
            cmbCategory = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            btnCancel = new PFC.App.Controls.SfRoundedButton();
            btnSave = new PFC.App.Controls.SfRoundedButton();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).BeginInit();
            gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            SuspendLayout();
            // 
            // gradientPanel1
            // 
            gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, Color.FromArgb(227, 199, 166), Color.FromArgb(245, 230, 211));
            gradientPanel1.Controls.Add(sfRoundedButtonAddSize);
            gradientPanel1.Controls.Add(dataGridView1);
            gradientPanel1.Controls.Add(label5);
            gradientPanel1.Controls.Add(cmbCategory);
            gradientPanel1.Controls.Add(btnCancel);
            gradientPanel1.Controls.Add(btnSave);
            gradientPanel1.Controls.Add(txtName);
            gradientPanel1.Controls.Add(label4);
            gradientPanel1.Controls.Add(label3);
            gradientPanel1.Controls.Add(label2);
            gradientPanel1.Controls.Add(label1);
            gradientPanel1.Dock = DockStyle.Fill;
            gradientPanel1.Location = new Point(0, 0);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(661, 520);
            gradientPanel1.TabIndex = 2;
            // 
            // sfRoundedButtonAddSize
            // 
            sfRoundedButtonAddSize.BackColor = Color.White;
            sfRoundedButtonAddSize.FlatStyle = FlatStyle.Flat;
            sfRoundedButtonAddSize.Font = new Font("Segoe UI Semibold", 9F);
            sfRoundedButtonAddSize.Location = new Point(20, 190);
            sfRoundedButtonAddSize.Name = "sfRoundedButtonAddSize";
            sfRoundedButtonAddSize.Size = new Size(120, 27);
            sfRoundedButtonAddSize.Style.BackColor = Color.White;
            sfRoundedButtonAddSize.Style.FocusedBackColor = Color.LemonChiffon;
            sfRoundedButtonAddSize.Style.FocusedBorder = null;
            sfRoundedButtonAddSize.Style.HoverBackColor = Color.FromArgb(221, 184, 146);
            sfRoundedButtonAddSize.Style.HoverForeColor = Color.Black;
            sfRoundedButtonAddSize.TabIndex = 11;
            sfRoundedButtonAddSize.Text = "Add Size";
            sfRoundedButtonAddSize.UseVisualStyleBackColor = false;
            sfRoundedButtonAddSize.Click += SfRoundedButtonAddSize_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Sizeoption, Price, Cost, Actions });
            dataGridView1.GridColor = SystemColors.HighlightText;
            dataGridView1.Location = new Point(41, 229);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(578, 186);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            // 
            // Sizeoption
            // 
            Sizeoption.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            Sizeoption.HeaderText = "Size";
            Sizeoption.MinimumWidth = 6;
            Sizeoption.Name = "Sizeoption";
            Sizeoption.Width = 165;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.Width = 125;
            // 
            // Cost
            // 
            Cost.HeaderText = "Cost";
            Cost.MinimumWidth = 6;
            Cost.Name = "Cost";
            Cost.Width = 125;
            // 
            // Actions
            // 
            Actions.HeaderText = "Actions";
            Actions.MinimumWidth = 6;
            Actions.Name = "Actions";
            Actions.Text = "Delete";
            Actions.UseColumnTextForButtonValue = true;
            Actions.Width = 110;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 161);
            label5.Name = "label5";
            label5.Size = new Size(221, 25);
            label5.TabIndex = 10;
            label5.Text = " Size and Pricing Options";
            // 
            // cmbCategory
            // 
            cmbCategory.Height = 28;
            cmbCategory.Location = new Point(356, 116);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(249, 28);
            cmbCategory.TabIndex = 9;
            cmbCategory.TextBoxHeight = 28;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(489, 446);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 35);
            btnCancel.Style.BackColor = Color.White;
            btnCancel.Style.FocusedBorder = null;
            btnCancel.Style.HoverBackColor = Color.Red;
            btnCancel.Style.HoverForeColor = Color.Black;
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.White;
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(346, 446);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(116, 35);
            btnSave.Style.BackColor = Color.White;
            btnSave.Style.FocusedBorder = null;
            btnSave.Style.HoverBackColor = Color.FromArgb(128, 255, 128);
            btnSave.Style.HoverForeColor = Color.Black;
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(100, 27);
            txtName.BorderStyle = BorderStyle.None;
            txtName.CornerRadius = 7;
            txtName.Location = new Point(52, 120);
            txtName.MinimumSize = new Size(28, 24);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "e.g Spanish Latte";
            txtName.Size = new Size(243, 24);
            txtName.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(356, 88);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 5;
            label4.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 88);
            label3.Name = "label3";
            label3.Size = new Size(136, 25);
            label3.TabIndex = 4;
            label3.Text = "Product Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 38);
            label2.Name = "label2";
            label2.Size = new Size(271, 25);
            label2.TabIndex = 3;
            label2.Text = "Fill in details for the new product";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 7);
            label1.Name = "label1";
            label1.Size = new Size(149, 31);
            label1.TabIndex = 2;
            label1.Text = "Add Product";
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 520);
            Controls.Add(gradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddProductForm";
            Load += AddProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).EndInit();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Label label1;
        private Label label2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Label label4;
        private Label label3;
        private Controls.SfRoundedButton btnCancel;
        private Controls.SfRoundedButton btnSave;
        private DataGridView dataGridView1;
        private Label label5;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbCategory;
        private Controls.SfRoundedButton sfRoundedButtonAddSize;
        private DataGridViewComboBoxColumn Sizeoption;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewButtonColumn Actions;
    }
}