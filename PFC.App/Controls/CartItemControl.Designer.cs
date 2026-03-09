namespace PFC.App.Controls
{
    partial class CartItemControl
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
            lblQuantity = new Label();
            lblProductName = new Label();
            lblDetails = new Label();
            btnRemove = new SfRoundedButton();
            lblLineTotal = new Label();
            SuspendLayout();
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(3, 11);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(35, 28);
            lblQuantity.TabIndex = 0;
            lblQuantity.Text = "1x";
            // 
            // lblProductName
            // 
            lblProductName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(44, 16);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(57, 23);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Name";
            // 
            // lblDetails
            // 
            lblDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDetails.AutoSize = true;
            lblDetails.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDetails.ForeColor = Color.Black;
            lblDetails.Location = new Point(20, 55);
            lblDetails.Name = "lblDetails";
            lblDetails.Size = new Size(50, 17);
            lblDetails.TabIndex = 2;
            lblDetails.Text = "Details";
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemove.BackColor = Color.SkyBlue;
            btnRemove.Font = new Font("Segoe UI Semibold", 9F);
            btnRemove.ImageSize = new Size(30, 30);
            btnRemove.Location = new Point(195, 111);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(40, 39);
            btnRemove.Style.BackColor = Color.SkyBlue;
            btnRemove.Style.FocusedBorder = null;
            btnRemove.Style.Image = Properties.Resources.bin;
            btnRemove.TabIndex = 3;
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += BtnRemove_Click;
            // 
            // lblLineTotal
            // 
            lblLineTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLineTotal.AutoSize = true;
            lblLineTotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLineTotal.ForeColor = Color.DarkGreen;
            lblLineTotal.Location = new Point(167, 16);
            lblLineTotal.Name = "lblLineTotal";
            lblLineTotal.Size = new Size(49, 23);
            lblLineTotal.TabIndex = 4;
            lblLineTotal.Text = "Price";
            // 
            // CartItemControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            Controls.Add(lblLineTotal);
            Controls.Add(btnRemove);
            Controls.Add(lblDetails);
            Controls.Add(lblProductName);
            Controls.Add(lblQuantity);
            Margin = new Padding(0, 0, 0, 5);
            Name = "CartItemControl";
            Size = new Size(250, 168);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuantity;
        private Label lblProductName;
        private Label lblDetails;
        private SfRoundedButton btnRemove;
        private Label lblLineTotal;
    }
}
