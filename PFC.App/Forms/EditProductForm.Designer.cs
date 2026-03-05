namespace PFC.App.Forms
{
    partial class EditProductForm
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
            label4 = new Label();
            label3 = new Label();
            btnCancel = new PFC.App.Controls.SfRoundedButton();
            btnSave = new PFC.App.Controls.SfRoundedButton();
            dataGridView1 = new DataGridView();
            Sizeoption = new DataGridViewComboBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Cost = new DataGridViewTextBoxColumn();
            Actions = new DataGridViewButtonColumn();
            sfRoundedButtonAddSize = new PFC.App.Controls.SfRoundedButton();
            cmbCategory = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
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
            gradientPanel1.Controls.Add(label4);
            gradientPanel1.Controls.Add(label3);
            gradientPanel1.Controls.Add(btnCancel);
            gradientPanel1.Controls.Add(btnSave);
            gradientPanel1.Controls.Add(dataGridView1);
            gradientPanel1.Controls.Add(sfRoundedButtonAddSize);
            gradientPanel1.Controls.Add(cmbCategory);
            gradientPanel1.Controls.Add(txtName);
            gradientPanel1.Controls.Add(label2);
            gradientPanel1.Controls.Add(label1);
            gradientPanel1.Dock = DockStyle.Fill;
            gradientPanel1.Location = new Point(0, 0);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(643, 473);
            gradientPanel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label4.Location = new Point(356, 92);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 14;
            label4.Text = "Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            label3.Location = new Point(52, 92);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 13;
            label3.Text = "Product Name";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCancel.Location = new Point(489, 421);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 35);
            btnCancel.Style.FocusedBorder = null;
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnSave.Location = new Point(346, 421);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(116, 35);
            btnSave.Style.FocusedBorder = null;
            btnSave.TabIndex = 11;
            btnSave.Text = "Save Product";
            btnSave.Click += btnSave_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Sizeoption, Price, Cost, Actions });
            dataGridView1.Location = new Point(32, 207);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(578, 186);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            // sfRoundedButtonAddSize
            // 
            sfRoundedButtonAddSize.BackColor = Color.Snow;
            sfRoundedButtonAddSize.Font = new Font("Segoe UI Semibold", 9F);
            sfRoundedButtonAddSize.Location = new Point(20, 165);
            sfRoundedButtonAddSize.Name = "sfRoundedButtonAddSize";
            sfRoundedButtonAddSize.Size = new Size(120, 27);
            sfRoundedButtonAddSize.Style.BackColor = Color.Snow;
            sfRoundedButtonAddSize.Style.FocusedBorder = null;
            sfRoundedButtonAddSize.TabIndex = 8;
            sfRoundedButtonAddSize.Text = "Add Size";
            sfRoundedButtonAddSize.UseVisualStyleBackColor = false;
            sfRoundedButtonAddSize.Click += sfRoundedButtonAddSize_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.BackColor = Color.FromArgb(255, 255, 255);
            cmbCategory.Border3DStyle = Border3DStyle.Flat;
            cmbCategory.ForeColor = Color.FromArgb(68, 68, 68);
            cmbCategory.Height = 34;
            cmbCategory.Items.AddRange(new object[] { "Iced Coffee", "Hot Coffee", "Flavored Milk", "Matcha", "Soda" });
            cmbCategory.Location = new Point(356, 119);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(249, 34);
            cmbCategory.TabIndex = 6;
            cmbCategory.TextBoxHeight = 26;
            cmbCategory.ThemeName = "Office2016Colorful";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(249, 27);
            txtName.Location = new Point(52, 120);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "\"e.g Vanilla Latte\"";
            txtName.Size = new Size(243, 27);
            txtName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 38);
            label2.Name = "label2";
            label2.Size = new Size(490, 25);
            label2.TabIndex = 4;
            label2.Text = "Fill in the details to add a new item to your shop's inventory.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 7);
            label1.Name = "label1";
            label1.Size = new Size(147, 31);
            label1.TabIndex = 3;
            label1.Text = "Edit Product";
            // 
            // EditProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 473);
            Controls.Add(gradientPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EditProductForm";
            Text = "EditProductForm";
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
        private Controls.SfRoundedButton sfRoundedButtonAddSize;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbCategory;
        private Controls.SfRoundedButton btnSave;
        private DataGridView dataGridView1;
        private Controls.SfRoundedButton btnCancel;
        private Label label3;
        private Label label4;
        private DataGridViewComboBoxColumn Sizeoption;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Cost;
        private DataGridViewButtonColumn Actions;
    }
}