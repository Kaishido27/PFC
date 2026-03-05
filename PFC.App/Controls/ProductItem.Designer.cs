namespace PFC.App.Controls
{
    partial class ProductItem
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
            pfcRoundedGradientPanel1 = new PfcRoundedGradientPanel();
            btnEdit = new Button();
            lblPrice = new Label();
            lblCategory = new Label();
            lblName = new Label();
            ((System.ComponentModel.ISupportInitialize)pfcRoundedGradientPanel1).BeginInit();
            pfcRoundedGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pfcRoundedGradientPanel1
            // 
            pfcRoundedGradientPanel1.BorderColor = Color.White;
            pfcRoundedGradientPanel1.BorderStyle = BorderStyle.None;
            pfcRoundedGradientPanel1.Controls.Add(btnEdit);
            pfcRoundedGradientPanel1.Controls.Add(lblPrice);
            pfcRoundedGradientPanel1.Controls.Add(lblCategory);
            pfcRoundedGradientPanel1.Controls.Add(lblName);
            pfcRoundedGradientPanel1.Dock = DockStyle.Fill;
            pfcRoundedGradientPanel1.Location = new Point(0, 0);
            pfcRoundedGradientPanel1.Name = "pfcRoundedGradientPanel1";
            pfcRoundedGradientPanel1.Size = new Size(226, 265);
            pfcRoundedGradientPanel1.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Transparent;
            btnEdit.Image = Properties.Resources.edit_minimized;
            btnEdit.Location = new Point(178, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(45, 48);
            btnEdit.TabIndex = 3;
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(13, 220);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(59, 28);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "Price";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(23, 54);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(72, 20);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Category";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(13, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 25);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // ProductItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pfcRoundedGradientPanel1);
            Margin = new Padding(10, 5, 3, 3);
            Name = "ProductItem";
            Size = new Size(226, 265);
            ((System.ComponentModel.ISupportInitialize)pfcRoundedGradientPanel1).EndInit();
            pfcRoundedGradientPanel1.ResumeLayout(false);
            pfcRoundedGradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PfcRoundedGradientPanel pfcRoundedGradientPanel1;
        private Label lblName;
        private Label lblPrice;
        private Label lblCategory;
        private Button btnEdit;
    }
}
