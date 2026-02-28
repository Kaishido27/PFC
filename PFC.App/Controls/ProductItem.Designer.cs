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
            lblName = new Label();
            lblCategory = new Label();
            lblPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)pfcRoundedGradientPanel1).BeginInit();
            pfcRoundedGradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pfcRoundedGradientPanel1
            // 
            pfcRoundedGradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, Color.BurlyWood, Color.Beige);
            pfcRoundedGradientPanel1.BorderColor = Color.White;
            pfcRoundedGradientPanel1.BorderStyle = BorderStyle.None;
            pfcRoundedGradientPanel1.Controls.Add(lblPrice);
            pfcRoundedGradientPanel1.Controls.Add(lblCategory);
            pfcRoundedGradientPanel1.Controls.Add(lblName);
            pfcRoundedGradientPanel1.Dock = DockStyle.Fill;
            pfcRoundedGradientPanel1.Location = new Point(0, 0);
            pfcRoundedGradientPanel1.Name = "pfcRoundedGradientPanel1";
            pfcRoundedGradientPanel1.Size = new Size(205, 219);
            pfcRoundedGradientPanel1.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(15, 19);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 25);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.Transparent;
            lblCategory.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategory.Location = new Point(31, 59);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(69, 20);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(15, 157);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(54, 25);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price";
            // 
            // ProductItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pfcRoundedGradientPanel1);
            Margin = new Padding(10);
            Name = "ProductItem";
            Size = new Size(205, 219);
            ((System.ComponentModel.ISupportInitialize)pfcRoundedGradientPanel1).EndInit();
            pfcRoundedGradientPanel1.ResumeLayout(false);
            pfcRoundedGradientPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PfcRoundedGradientPanel pfcRoundedGradientPanel1;
        private Label lblCategory;
        private Label lblName;
        private Label lblPrice;
    }
}
